using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Interfaces
{
    public interface IIniFile
    {
        public List<IniSection> Sections { get; set; }
    }
}
