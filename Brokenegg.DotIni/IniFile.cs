using Brokenegg.DotIni.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniFile
    {
        public List<IniSection> Sections { get; set; }
        private string FileName { get; set; }

        public IniFile()
        {
            this.Sections = new List<IniSection>();
            this.FileName = String.Empty;
        }

        public bool HasSection() => this.Sections.ToArray().Length > 0;
        public void AddDefaultSection() => this.Sections.Add(new IniSection("default"));
        public void AddSection(string name) => this.Sections.Add(new IniSection(name));
        public void AddSection(IniSection iniSection) => this.Sections.Add(iniSection);
        public void AddKeyParLastSection(IniKey iniKey)
        {
            if (iniKey == null) return;
            this.Sections[this.Sections.Count - 1].AddIniKey(iniKey);
        }
        public void AddKeyParLastSection(string name, string value) => this.AddKeyParLastSection(new IniKey(name, value));
        public IniSection FindSection(string name)
        {
            return this.Sections.Where(p => p.SectionName.Equals(name))?.FirstOrDefault();
        }
        public IniKey FindIniKey(string section, string name)
        {
            return this.FindSection(section)?.FindIniKey(name);
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            this.Sections.ForEach(s =>
            {
                builder.AppendLine(IniUtils.ToStringSection(s.SectionName));
                s.Keys.ForEach(k =>
                {
                    builder.Append(IniUtils.ToStringKeyPar(k.Name, k.KeyValue));
                });
            });
            return builder.ToString();
        }
    }
}
