using Brokenegg.DotIni.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Validations
{
    public class KeyValidation
    {
        private Validator Validator { get; set; }

        private IniKey Key { get; set; }
        public KeyValidation(IniKey key)
        {
            this.Validator = new Validator();
            this.Key = key;
        }

        public bool IsValid() => this.Validator.IsValid();
        public string GetError() => this.Validator.GetNotification();
        public string[] GetErrors() => this.Validator.GetNotifications();

        public void Validate(bool throwException = true)
        {
            this.Validator
                .IsNull(this.Key, "Key should not be empty")
                .IsNullOrEmpty(this.Key?.Name, "Key name should not be empty");

            if (!this.IsValid() && throwException) ThrowException();
        }

        public void ThrowException() => throw new IniValidationException(this.GetErrors());
    }
}
