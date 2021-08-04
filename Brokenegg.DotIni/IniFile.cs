using Brokenegg.DotIni.Exceptions;
using Brokenegg.DotIni.Interfaces;
using Brokenegg.DotIni.Utils;
using Brokenegg.DotIni.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniFile : IValidation
    {
        /// <summary>
        /// IniFile sections
        /// </summary>
        public List<IniSection> Sections { get; set; }
        private string FileLocation { get; set; }

        public bool IsValid() => new IniFileValidations(this).IsValid();
        public void Validate(bool throwException = true) => new IniFileValidations(this).Validate();
        public IniFile()
        {
            this.Sections = new List<IniSection>();
            this.FileLocation = String.Empty;
        }
        /// <summary>
        /// Check if the file has sections
        /// </summary>
        /// <returns></returns>
        public bool HasSection() => this.Sections?.ToArray().Length > 0;
        /// <summary>
        /// Add default section to be used on cases where there is no section
        /// </summary>
        public void AddDefaultSection() => this.Sections.Add(new IniSection("default"));
        public void AddSection(string name) => this.Sections.Add(new IniSection(name));
        public void AddSection(IniSection iniSection)
        {
            if (!iniSection.IsValid()) iniSection.Validate();
            this.Sections.Add(iniSection);
        }
        public bool AddKeyParLastSection(IniKey iniKey)
        {
            if (iniKey == null) throw new Exceptions.KeyNotFoundException();
            if (!iniKey?.IsValid() ?? true) iniKey.Validate();
            if (this.Sections.Count == 0) throw new SectionNotFoundException();

            this.Sections[this.Sections.Count - 1].AddIniKey(iniKey);
            return true;
        }
        public void AddKeyParLastSection(string name, string value) => this.AddKeyParLastSection(new IniKey(name, value));
        /// <summary>
        /// Find a section based on the section name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniSection FindSection(string name)
        {
            return this.Sections.Where(p => p.SectionName.Equals(name))?.FirstOrDefault();
        }
        /// <summary>
        /// Find a key-par value based on the section name and key name
        /// </summary>
        /// <param name="section"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniKey FindIniKey(string section, string name)
        {
            return this.FindSection(section)?.FindIniKey(name);
        }
        /// <summary>
        /// Serialize object to Strinf
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var ini = new StringBuilder();
            this.Sections.ForEach(s =>
            {
                ini.AppendLine(s.ToIniString());
                s.Keys.ForEach(k =>
                {
                    ini.AppendLine(k.ToIniString());
                });
            });

            return ini.ToString();
        }
        /// <summary>
        /// Get Inifile from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IniFile GetFromFile(string path)
        {
            var iniFile = IniConvert.DeserializeObject(FileUtils.ReadFile(path));
            iniFile.SetFileLocation(path);
            return iniFile;
        }

        private void SetFileLocation(string fileLocation)
        {
            this.FileLocation = fileLocation;
        }        
    }
}
