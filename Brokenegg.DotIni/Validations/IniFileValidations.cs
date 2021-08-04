using Brokenegg.DotIni.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Validations
{
    public class IniFileValidations
    {
        private Validator Validator { get; set; }
        private IniFile IniFile { get; set; }
        public IniFileValidations(IniFile iniFile)
        {
            this.Validator = new Validator();
            this.IniFile = iniFile;
        }

        public bool IsValid() => this.Validator.IsValid();
        public string GetError() => this.Validator.GetNotification();
        public string[] GetErrors() => this.Validator.GetNotifications();

        public void Validate(bool throwException = true)
        {
            this.Validator
                .IsNull(this.IniFile, "IniFile should not be empty")
                .HasMoreThanOne(this.IniFile?.Sections?.Count, "Key name should not be empty");

            if (!this.IsValid() && throwException) ThrowException();
        }

        public void ThrowException() => throw new IniValidationException(this.GetErrors());
    }
}
