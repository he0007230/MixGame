using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    public class DeptData : GameData<DeptData>
    {
        public string deptNo { get; protected set; }
        public string deptName { get; protected set; }
        static public readonly string fileName = "xml/Dept";
    }
}
