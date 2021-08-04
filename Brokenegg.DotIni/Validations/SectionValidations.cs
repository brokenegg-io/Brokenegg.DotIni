using Brokenegg.DotIni.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brokenegg.DotIni.Validations
{
    public class SectionValidations
    {
        private Validator Validator { get; set; }
       
        private IniSection Section { get; set; }
        public SectionValidations(IniSection section)
        {
            this.Validator = new Validator();
            this.Section = section;
        }

        public bool IsValid() => this.Validator.IsValid();
        public string GetError() => this.Validator.GetNotification();
        public string[] GetErrors() => this.Validator.GetNotifications();

        public void Validate(bool throwException = true)
        {
            this.Validator
                .IsNullOrEmpty(this.Section.SectionName, "Section name should not be empty")
                .ContainSpaces(this.Section.SectionName, "Section name should not contain any spaces")
                .OnlyContainCharacters(this.Section.SectionName, "Invalid characters found", true);

            if (!this.IsValid() && throwException) ThrowException();
        }

        public void ThrowException() => throw new IniValidationException(this.GetErrors());
    }
}
