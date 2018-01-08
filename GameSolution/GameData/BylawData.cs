using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    public class BylawData:GameData<BylawData>
    {
        public string rank1Code { get; protected set; }
        public string rank1Name { get; protected set; }
        public string rank2Code { get; protected set; }
        public string rank2Name { get; protected set; }
        public string rank3Code { get; protected set; }
        public string rank3Name { get; protected set; }
        public string rank4Code { get; protected set; }
        public string rank4Name { get; protected set; }
        public string punish { get; protected set; }
        public string leader { get; protected set; }
        public string director { get; protected set; }
        public List<string> department { get; protected set; }
        public string amount_mark { get; protected set; }
        static public readonly string fileName = "xml/Bylaw";
    }
}
