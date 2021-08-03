using Brokenegg.DotIni.Exceptions;
using Brokenegg.DotIni.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniFile
    {
        /// <summary>
        /// IniFile sections
        /// </summary>
        public List<IniSection> Sections { get; set; }
        private string FileName { get; set; }

        public IniFile()
        {
            this.Sections = new List<IniSection>();
            this.FileName = String.Empty;
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
        public void AddSection(IniSection iniSection) => this.Sections.Add(iniSection);
        public void AddKeyParLastSection(IniKey iniKey)
        {
            if (iniKey == null) throw new NullKeyException();
            this.Sections[this.Sections.Count - 1].AddIniKey(iniKey);
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
    }
}
