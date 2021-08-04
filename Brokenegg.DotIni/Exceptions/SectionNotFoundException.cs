using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Exceptions
{
    public class SectionNotFoundException: Exception
    {
        public SectionNotFoundException() : base("Section could not be found")
        {

        }
    }
}
