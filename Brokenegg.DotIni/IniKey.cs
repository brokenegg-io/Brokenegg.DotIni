using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni
{
    public class IniKey
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

        public IniKey(string name, IniValue value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string ToIniString() => $"{this.Name}={this.KeyValue}";
    }
}
