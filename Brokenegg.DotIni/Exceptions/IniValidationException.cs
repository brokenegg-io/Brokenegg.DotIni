using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Exceptions
{
    public class IniValidationException: Exception
    {
        public IniValidationException(string[] notifications, Exception innerException = null) 
            : base(string.Join("\n", notifications), innerException)
        {

        }
    }
}
