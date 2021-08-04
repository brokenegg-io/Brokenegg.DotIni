using Brokenegg.DotIni.Interfaces;
using Brokenegg.DotIni.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniKey : IValidation
    {
        public string Name { get; set; }
        public string KeyValue
        {
            get
            {
                return Value.To<string>();
            }
        }
        public IniValue Value { get; set; }

        public T GetValue<T>()
        {
            if (typeof(T) == this.Value.ValueType()) return Value.To<T>();
            return default(T);
        }

        public int GetInt() => GetValue<int>();
        public string GetString() => GetValue<string>();
        public decimal GetDecimal() => GetValue<decimal>();
        public bool GetBoolean() => GetValue<bool>();
        private void _Constructor(string name, IniValue value)
        {
            this.Name = name;
            this.Value = value;

            this.Validate();
        }

        public IniKey(string name, string value) => _Constructor(name, new IniValue(value.ToString()));
        public IniKey(string name, int value) => _Constructor(name, new IniValue(value.ToString()));
        public IniKey(string name, IniValue value) => _Constructor(name, value);

        public string ToIniString() => $"{this.Name}={this.KeyValue}";

        public bool IsValid() => new KeyValidation(this).IsValid();

        public void Validate(bool throwException = true) => new KeyValidation(this).Validate(throwException);
    }
}
