using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    public class CheckPointData:GameData<CheckPointData>
    {
        public string bylawCode { get; protected set; }
        public int groupNo { get; protected set; }
        public string postDesc { get; protected set; }
        public int point { get; protected set; }
        static public readonly string fileName = "xml/CheckPoint";
    }
}
