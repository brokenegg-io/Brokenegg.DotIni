using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniSection
    {
        public string SectionName { get; set; }
        public List<IniKey> Keys { get; set; }

        public IniSection(string sectionName)
        {
            this.Keys = new List<IniKey>();
            this.SectionName = sectionName;
        }

        public T GetValue<T>(string name)
        {
            return
                this.Keys.Where(p => p.Name.Equals(name))
                .Select(p => p.GetValue<T>())
                .FirstOrDefault() ?? default(T);
        }

        public void AddIniKey(IniKey iniKey)
        {
            this.Keys.Add(iniKey);
        }

        public IniKey FindIniKey(string name)
        {
            return this.Keys.Where(p => p.Name.Equals(name))?.FirstOrDefault();
        }

        public string ToIniString() => $"[{this.SectionName}]";
    }
}
