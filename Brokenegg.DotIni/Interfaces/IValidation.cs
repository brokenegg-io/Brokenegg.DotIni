using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Interfaces
{
    public interface IValidation
    {
        public bool IsValid();
        public void Validate(bool throwException = true);
    }
}
