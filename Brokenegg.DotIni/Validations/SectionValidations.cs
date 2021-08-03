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

        private char[] InvalidSectionNameChars => new List<Char>(){ 'Ã', 'ã', 'Ç', 'ç', 'ñ', 'Ñ', 'Ü', 'ü', 'õ', 'ã', '!', '$' }.ToArray();
        private char[] ValidSectionNameChars => new List<Char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }.ToArray();

        public SectionValidations(IniSection section)
        {
            this.Validator = new Validator();
            this.Section = section;
        }

        public bool IsValid() => this.Validator.IsValid();
        public string GetError() => this.Validator.GetNotification();
        public string[] GetErrors() => this.Validator.GetNotifications();

        public void Validate()
        {
            this.Validator
                .IsNullOrEmpty(this.Section.SectionName, "Section name should not be empty")
                .ContainSpaces(this.Section.SectionName, "Section name should not contain any spaces")
                .OnlyContainCharacters(this.Section.SectionName, ValidSectionNameChars, "Invalid characters found", true);

            if (!this.IsValid()) ThrowException();
        }

        public void ThrowException() => throw new IniValidationException(this.GetErrors());
    }
}
