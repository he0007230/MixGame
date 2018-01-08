using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData
{
    public class StockData : GameData<StockData>
    {
        public string stockNo { get; protected set; }
        public string stockName { get; protected set; }
        public string ssid { get; protected set; }
        public string pwd { get; protected set; }
        public string ip { get; protected set; }
        public string gateway { get; protected set; }
        public string serverIP { get; protected set; }
        public string serverPort { get; protected set; }
        static public readonly string fileName = "xml/Stock";

    }
}
