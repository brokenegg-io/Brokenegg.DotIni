using Brokenegg.DotIni.Interfaces;
using Brokenegg.DotIni.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni
{
    /// <summary>
    /// The ini section represents the section of an ini file, as represented
    /// [sectionName]
    /// </summary>
    public class IniSection : IValidation
    {
        public string SectionName { get; set; }
        public List<IniKey> Keys { get; set; }

        public IniSection(string sectionName)
        {
            this.Keys = new List<IniKey>();
            this.SectionName = sectionName;

            this.Validate();
        }
        public T GetValue<T>(string name)
        {
            return
                this.Keys.Where(p => p.Name.Equals(name))
                .Select(p => p.GetValue<T>())
                .FirstOrDefault() ?? default(T);
        }
        /// <summary>
        /// Adds a key to the current section
        /// </summary>
        /// <param name="iniKey"></param>
        public void AddIniKey(IniKey iniKey)
        {
            if (!iniKey?.IsValid() ?? false) iniKey.Validate();
            this.Keys.Add(iniKey);
        }
        /// <summary>
        /// Finds a value from a given key
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniKey FindIniKey(string name)
        {
            return this.Keys.Where(p => p.Name.Equals(name))?.FirstOrDefault();
        }
        /// <summary>
        /// Return the string representation of a section
        /// </summary>
        /// <returns></returns>
        public string ToIniString() => $"[{this.SectionName}]";
        /// <summary>
        /// Return if the section is a valid one
        /// </summary>
        /// <returns></returns>
        public bool IsValid() => new SectionValidations(this).IsValid();
        /// <summary>
        /// Validate a section and throws an exception if not valid
        /// </summary>
        public void Validate(bool throwException = true) => new SectionValidations(this).Validate(throwException);
        public bool Valid => this.IsValid();
    }
}
