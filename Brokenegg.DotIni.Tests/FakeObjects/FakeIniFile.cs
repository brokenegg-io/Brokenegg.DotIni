using Brokenegg.DotIni.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brokenegg.DotIni.Tests.FakeObjects
{
    public class FakeIniFile: IniFile
    {
        public FakeIniFile() : base()
        {
            this.Sections = new List<IniSection>();
        }
    }
}
