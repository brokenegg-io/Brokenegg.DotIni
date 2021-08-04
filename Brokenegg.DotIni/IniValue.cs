using Brokenegg.DotIni.Utils;
using System;

namespace Brokenegg.DotIni
{
    public class IniValue
    {
        private object Value { get; set; }
        private Type Type { get; set; }

        public IniValue(object value)
        {
            this.Type = IniUtils.FindMyType(value);
            this.Value = Convert.ChangeType(value, this.Type);
        }

        public Type ValueType() => this.Type;

        public T To<T>()
        {
            return (T)Convert.ChangeType(this.Value, typeof(T));
        }
    }
}
