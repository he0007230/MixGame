using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using LogHelper;
using System.Configuration;
using NewMatServerCMD.Model;
using System.Xml;
using NewMatServerCMD.DB;
using NewMatServerCMD.tool;
using System.Data;

namespace NewMatServerCMD
{
    public class Config
    {
        private static Config _instance;
        public SysInfo sysInfo;
        public Dictionary<int, RedirectModel> redirectDict;
        public delegate void actionByMain(object tranObj, RedirectModel redirecgtModel, out object message);
        public Dictionary<string, actionByMain> mainList;
        public string outStr;
        public string[] appName;
        public string[] appVersion;
        public string[] appPath;
        public int timeoutCount;

        private Config() 
        {
            LoadProfile();
        }

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
 
        }
        private void LoadProfile()
        {
            try
            {
                //using (FileStream fs = new FileStream("D:\\MatServer\\CONFIG.XML", FileMode.Open))
                //{
                    //XmlSerializer formatter = new XmlSerializer(typeof(XmlData));
                    //xmlData = (XmlData)formatter.Deserialize(fs);
                //}
                timeoutCount = 0;
                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.Load("D:\\MatServer\\CONFIG.XML");
                sysInfo = new SysInfo();
                sysInfo.name = xmlDoc1.SelectSingleNode("Root/System/name").InnerText;
                sysInfo.version = xmlDoc1.SelectSingleNode("Root/System/version").InnerText;
                sysInfo.wince_path = xmlDoc1.SelectSingleNode("Root/System/wince_path").InnerText;
                sysInfo.pc_path = xmlDoc1.SelectSingleNode("Root/System/pc_path").InnerText;
                sysInfo.stock_name = xmlDoc1.SelectSingleNode("Root/System/stock_name").InnerText;
                sysInfo.stock_no = xmlDoc1.SelectSingleNode("Root/System/stock_no").InnerText;
                sysInfo.server_ip = xmlDoc1.SelectSingleNode("Root/System/server_ip").InnerText;
                sysInfo.server_port = int.Parse(xmlDoc1.SelectSingleNode("Root/System/server_port").InnerText);
                sysInfo.maxSessionTimeout = int.Parse(xmlDoc1.SelectSingleNode("Root/System/maxSessionTimeout").InnerText);
                sysInfo.remoteServer = xmlDoc1.SelectSingleNode("Root/System/remoteServer").InnerText;
                sysInfo.maxListener = int.Parse(xmlDoc1.SelectSingleNode("Root/System/maxListener").InnerText);
                sysInfo.printName = xmlDoc1.SelectSingleNode("Root/System/printName").InnerText;
                sysInfo.officePrintName = xmlDoc1.SelectSingleNode("Root/System/officePrintName").InnerText;
                sysInfo.ttspaServer = xmlDoc1.SelectSingleNode("Root/System/ttspaServer").InnerText;
                

                

                if (xmlDoc1.SelectSingleNode("Root/System/recordCodeStr").InnerText == "Y")
                {
                    sysInfo.recordCodeStr = true;
                }
                else
                {
                    sysInfo.recordCodeStr = false;
                }
                if (xmlDoc1.SelectSingleNode("Root/System/recordOutStr").InnerText == "Y")
                {
                    sysInfo.recordOutStr = true;
                }
                else
                {
                    sysInfo.recordOutStr = false;
                }
                if (xmlDoc1.SelectSingleNode("Root/System/recordTestStr").InnerText == "Y")
                {
                    sysInfo.recordTestStr = true;
                }
                else
                {
                    sysInfo.recordTestStr = false;
                }
                XmlNode xn1 = xmlDoc1.SelectSingleNode("Root/Applications");
                XmlNodeList xnl1 = xn1.ChildNodes;
                appName = new String[xnl1.Count];
                appPath = new String[xnl1.Count];
                appVersion = new String[xnl1.Count];
                int i = 0;
                foreach (XmlNode cn1 in xnl1)
                {
                    appName[i] = cn1.SelectSingleNode("name").InnerText;
                    appPath[i] = cn1.SelectSingleNode("pc_path").InnerText;
                    appVersion[i] = cn1.SelectSingleNode("version").InnerText;
                    i++;
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("D:\\MatServer\\REDIRECT.XML");
                XmlNode xn = xmlDoc.SelectSingleNode("Root");
                XmlNodeList xnl = xn.ChildNodes;
                redirectDict = new Dictionary<int, RedirectModel>();
                foreach (XmlNode cn in xnl)
                {
                    RedirectModel redirectModel = new RedirectModel();
                    XmlElement xe = (XmlElement)cn;
                    redirectModel.id = int.Parse(xe.GetAttribute("ID").ToString());
                    redirectModel.redirectName = xe.GetAttribute("Name").ToString();
                    redirectModel.funcName = xe.SelectSingleNode("funcName").InnerText;
                    redirectModel.connStr = ConfigurationManager.ConnectionStrings[xe.SelectSingleNode("connStr").InnerText].ToString();
                    redirectModel.pkgName = ConfigurationManager.AppSettings[xe.SelectSingleNode("pkgName").InnerText];
                    redirectModel.pFlag = int.Parse(xe.SelectSingleNode("pflag").InnerText);
                    redirectModel.isCache = xe.SelectSingleNode("isCache").InnerText;
                    redirectModel.area = int.Parse(xe.SelectSingleNode("area").InnerText);
                    redirectModel.type = int.Parse(xe.SelectSingleNode("type").InnerText);
                    redirectModel.command = int.Parse(xe.SelectSingleNode("command").InnerText);
                    if (redirectDict.ContainsKey(redirectModel.id))
                    {
                        LoggerHelper.Info("重复加载处理模块 ID:" + redirectModel.id + " Name:" + redirectModel.redirectName, false, false);
                    }
                    else
                    {
                        redirectDict.Add(redirectModel.id, redirectModel);
                        LoggerHelper.Info("载入处理模块 ID:" + redirectModel.id + " Name:" + redirectModel.redirectName, false, false);
                    }
                }

                mainList = new Dictionary<string, actionByMain>();
                mainList.Add("nlscan_pkg", nlscan_pkg);
                mainList.Add("UpdateClientConfig", UpdateClientConfig);
                mainList.Add("CheckVersion", CheckVersion);
                mainList.Add("UpdateApplication",UpdateApplication);
                mainList.Add("Test", Test);
                mainList.Add("raspi_test", raspi_test);
                mainList.Add("fcl_check", fcl_check);
                mainList.Add("UpdateBylawData", UpdateBylawData);
                mainList.Add("PrintBylawData", PrintBylawData);
                mainList.Add("UpdateCheckPointData", UpdateCheckPointData);
                mainList.Add("DownloadStockConfig", DownloadStockConfig);
                mainList.Add("DownloadDeptConfig", DownloadDeptConfig);
                mainList.Add("DownloadTest", DownloadTest);
                mainList.Add("IntegralQuery1", IntegralQuery1);
                mainList.Add("IntegralQuery2", IntegralQuery2);

                LoggerHelper.Info("读取配置成功!");           
                
            }
            catch(Exception e)
            {
                LoggerHelper.Info("读取配置失败!  "+e.Message);
            }

        }

        //会员积分查询
        private void IntegralQuery1(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            string connStr = ConfigurationManager.ConnectionStrings["ttshopConnStr"].ToString();
            string outStr = OracleController.ttshopPkg(connStr, redirectModel.pkgName, redirectModel.pFlag
                   , transDTO.CodeStr, transDTO.IP, transDTO.AppName, transDTO.StockNo, redirectModel.isCache);
            //'卡号'||cardno||'卡状态'||sqlerrm
            if (outStr.Length == 0)
            {
                //string cardNo = outStr.Substring(3, 13);
                //string cardStatus = outStr;
                //////string str = "";

                string sqlStr = "select a.card_no,nvl(a.cust_name,''),a.eff_start_date,";
                sqlStr += "a.eff_end_date,nvl(a.curr_intl,0),nvl(a.bar_code_no,' '),";
                sqlStr += "nvl(a.mobl_tel,' '),nvl(a.chg_intl,0) from ttmember_card_info_tmp1 a";
                DataSet ds = OracleController.GetDataSet(connStr, sqlStr);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    message = "读卡错误！";
                }
                else
                {   
                    string str = ds.Tables[0].Rows[0][0].ToString() + "#" + ds.Tables[0].Rows[0][1].ToString();
                    str += "#" + ds.Tables[0].Rows[0][2].ToString() + "#" + ds.Tables[0].Rows[0][3].ToString();
                    str += "#" + ds.Tables[0].Rows[0][4].ToString() + "#" + ds.Tables[0].Rows[0][5].ToString();
                    str += "#" + ds.Tables[0].Rows[0][6].ToString() + "#" + ds.Tables[0].Rows[0][7].ToString();
                    message = str;
                }

            }
            else
            {
                message = outStr;
            }
        }
        //商品查询
        private void IntegralQuery2(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            string connStr = ConfigurationManager.ConnectionStrings["ttshopConnStr"].ToString();
            string sqlStr = "select stock_no from ttshop_stock where use_flag='Y'";
            DataSet ds = OracleController.GetDataSet(connStr, sqlStr);
            string stockNo = "";
            if (ds.Tables[0].Rows.Count == 0)
            {
                stockNo = "01";
            }
            else
            {
                stockNo = ds.Tables[0].Rows[0][0].ToString();
            }
            sqlStr = "select a.goods_no,a.goods_name,a.goods_spec,b.price,b.bat_price from ttshop_goods a,ttshop_goods_stk b,";
            sqlStr += "ttshop_goods_bar c where  a.goods_no=b.goods_no  and b.stock_no='" + stockNo + "'";
            sqlStr += " and a.goods_no=c.goods_no and c.bar_code='" + transDTO.CodeStr + "'";
            string flag1 = "0";
            ds = OracleController.GetDataSet(connStr, sqlStr);
            if (ds.Tables[0].Rows.Count == 0)
            {
                flag1 = "1";
                sqlStr = "select a.goods_no,a.goods_name,a.goods_spec,b.price,b.bat_price from ttshop_goods_s a";
                sqlStr += ",ttshop_goods_stk_s b,ttshop_goods_bar_s c where  a.goods_no=b.goods_no ";
                sqlStr += " and b.stock_no='" + stockNo + "' and a.goods_no=c.goods_no and c.bar_code='";
                sqlStr += transDTO.CodeStr + "'";
                ds = OracleController.GetDataSet(connStr, sqlStr);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    message = "商品条码错误！";
                }
                else
                {
                    string str = ds.Tables[0].Rows[0][0].ToString() + "#" + ds.Tables[0].Rows[0][1].ToString();
                    str += "#" + ds.Tables[0].Rows[0][2].ToString() + "#" + ds.Tables[0].Rows[0][3].ToString();
                    str += "#" + ds.Tables[0].Rows[0][4].ToString();
                    message = str;

                }
            }
            else
            {
                string str = ds.Tables[0].Rows[0][0].ToString() + "#" + ds.Tables[0].Rows[0][1].ToString();
                str += "#" + ds.Tables[0].Rows[0][2].ToString() + "#" + ds.Tables[0].Rows[0][3].ToString();
                str += "#" + ds.Tables[0].Rows[0][4].ToString();
                message = str;
            } 
        }

        private void raspi_test(object transObj, RedirectModel redirectModel, out object message)
        {
            LoggerHelper.Info("收到消息："+transObj.ToString());
            message = transObj.ToString();
        }

        private void fcl_check(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;

            string sqlStr = "select * from ttshop_bar_check_sts where bar_code='"+transDTO.CodeStr.Substring(0,13);
            sqlStr += "' and match_date>to_char(sysdate-8,'yyyymmddhh24miss')";
            if (OracleController.AdoSql(ConfigurationManager.ConnectionStrings["ttshopConnStr"].ToString(), sqlStr))
            {
                message = OracleController.NlscanPkg(ConfigurationManager.ConnectionStrings["ttshopConnStr"].ToString(), redirectModel.pkgName, redirectModel.pFlag
                   , transDTO.CodeStr+"00|", transDTO.IP, transDTO.AppName, transDTO.StockNo, redirectModel.isCache);
            }
            else if (OracleController.AdoSql(ConfigurationManager.ConnectionStrings["ttspaConnStr"].ToString(), sqlStr))
            {
                message = OracleController.NlscanPkg(ConfigurationManager.ConnectionStrings["ttspaConnStr"].ToString(), redirectModel.pkgName, redirectModel.pFlag
                    , transDTO.CodeStr + "01|", transDTO.IP, transDTO.AppName, transDTO.StockNo, redirectModel.isCache);
            }
            else
            {
                message = "没有此整箱条码！";
            }
            if (sysInfo.recordCodeStr)
            {
                LoggerHelper.Info("[" + transDTO.IP + "][" + redirectModel.redirectName + "][" + transDTO.CodeStr + "][" + transDTO.Remark + "]", false, false);
            }
            if (sysInfo.recordOutStr)
            {
                LoggerHelper.Info("[" + transDTO.IP + "][" + redirectModel.redirectName + "结果][" + message.ToString() + "]", false, false);
            }
        }

        private void nlscan_pkg(object transObj, RedirectModel redirectModel, out object message)
        {
            
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            //检测网络连通性，并且
            if (redirectModel.command % 5 == 0)
            {
                if (OracleController.PingIpOrDomainName(sysInfo.remoteServer))
                {
                    transDTO.CodeStr += "01|";
                }
                else
                {
                    transDTO.CodeStr += "00|";
                }
            }
            message = OracleController.NlscanPkg(redirectModel.connStr, redirectModel.pkgName, redirectModel.pFlag
                , transDTO.CodeStr, transDTO.IP, transDTO.AppName, transDTO.StockNo, redirectModel.isCache);
            if (redirectModel.command % 2 == 0)
            {
                //专柜数据
                message = OracleController.GetSpaData(message.ToString(), ConfigurationManager.ConnectionStrings["ttspaConnStr"].ToString());
            }
            else if (redirectModel.command % 3 == 0)
            {
                if (message.ToString().Contains("回执单号"))
                {
                    int i = message.ToString().IndexOf("回执单号")+4;
                    //message.ToString().Substring(i,13)
                    LoggerHelper.Info("打印司机送货回执:" + message.ToString().Substring(i, 13));
                    string sqlStr = "select receipt_no,trip_no,stock_name,worker_name,remark from ttmat_trip_receipt where receipt_no='";
                    sqlStr += message.ToString().Substring(i, 13) + "'";
                    PrintHelper.GetInstance().PrintReport(ConfigurationManager.ConnectionStrings["ttmatLocalConnStr"].ToString()
                        , sqlStr, "query1", "D://MatServer//ttmat_receipt.frx", Config.Instance.sysInfo.printName);
                }
                //打印司机送货回执
                //PrintHelper.GetInstance().PrintReport(
            }
            if (sysInfo.recordCodeStr)
            {
                LoggerHelper.Info("[" + transDTO.IP + "]["+redirectModel.redirectName+"][" + transDTO.CodeStr + "][" + transDTO.Remark + "]", false, false);
            }
            if (sysInfo.recordOutStr)
            {
                LoggerHelper.Info("[" + transDTO.IP + "]["+redirectModel.redirectName+"结果][" + message.ToString() + "]", false, false);
            }

        }

        private void UpdateClientConfig(object transObj, RedirectModel redirectMode, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            LoggerHelper.Info("[" + transDTO.IP + "][更新配置文件]");
            FileInfo sendFile = new FileInfo(sysInfo.pc_path);
            FileStream sendStream = sendFile.OpenRead();
            byte[] byte_data = new byte[sendStream.Length];
            sendStream.Read(byte_data, 0, byte_data.Length);
            message = byte_data;
        }
        private void CheckVersion(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            //LoggerHelper.Info(transDTO.IP + "  --CheckVersion");

            string[] data = transDTO.CodeStr.Split('#');
            string tmpstr="";
            int id = 0;
            if (data.Length == 2)
            {
                if (int.TryParse(data[0], out id))
                {
                    if (appVersion[id] == data[1])
                    {
                        message = "NEW";
                    }
                    else
                    {
                        message = "UPDATE#"+appVersion[id];
                    }
                    tmpstr = appName[id] + "->" + message.ToString();
                }
                else
                {
                    message = "ERROR";
                    tmpstr = "PARSE->" + message.ToString();
                }
                
            }
            else
            {
                message = "ERROR";
                tmpstr = "NULL->" + message.ToString();
            }
            LoggerHelper.Info("[" + transDTO.IP + "][检查程序版本]" + tmpstr);
        }
        private void UpdateApplication(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            int id = 0;
            if (int.TryParse(transDTO.CodeStr, out id))
            {
                FileInfo sendFile = new FileInfo(appPath[id]);
                FileStream sendStream = sendFile.OpenRead();
                byte[] byte_data = new byte[sendStream.Length];
                sendStream.Read(byte_data, 0, byte_data.Length);
                message = byte_data;
                LoggerHelper.Info("[" + transDTO.IP + "][更新程序->" + appName[id] + "][" + byte_data.Length + "]");
            }
            else
            {
                LoggerHelper.Info("[" + transDTO.IP + "][更新程序失败]");
                message = null;
            }
        }
        private void Test(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            if (sysInfo.recordTestStr)
            {
                LoggerHelper.Info("[" + transDTO.IP + "][测试数据][" + transDTO.CodeStr + "]", false, false);
            }
            message = "test";
        }

        private void DownloadTest(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
 
            LoggerHelper.Info("[" + transDTO.IP + "][读取数据！]");
            FileStream MyFileStream = new FileStream("d://Bylaw.xml", FileMode.Open, FileAccess.Read);
            byte[] tmp = new byte[MyFileStream.Length];
            MyFileStream.Read(tmp, 0,(int)MyFileStream.Length);
            MyFileStream.Close();
            message = tmp;

        }

        private void UpdateBylawData(object transObj, RedirectModel redirectModel, out object message)
        {

            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            LoggerHelper.Info("[" + transDTO.IP + "][下载考核明细数据中...]");
                string sqlStr = @"select row_number() over( order by a.type_code) ""id_i"",a.main_type_code3 ""rank1Code_s""";
            sqlStr += @",b.type_name ""rank1Name_s"",a.main_type_code4 ""rank2Code_s"",c.type_name ""rank2Name_s""";
            sqlStr += @",a.main_type_code ""rank3Code_s"",d.type_name ""rank3Name_s"",a.type_code ""rank4Code_s""";
            //sqlStr += @",a.type_name ""rank4Name_s"",a.oper_sts ""punish_s"",a.manager_sts1 ""leader_s""";
            sqlStr += @",a.type_name ""rank4Name_s"",'' ""punish_s"",'' ""leader_s""";
            sqlStr += @",a.amount_mark ""amount_mark""";
            //sqlStr += @",a.manager_sts2 ""director_s"",a.stock_name ""department_l"" from rs_check_type2 a";
            sqlStr += @",'' ""director_s"",'' ""department_l"" from rs_check_type2 a";
            sqlStr += @" left join rs_check_type3 b on a.main_type_code3=b.type_code";
            sqlStr += @" left join rs_check_type4 c on a.main_type_code4=c.type_code";
            sqlStr += @" left join rs_check_type1 d on a.main_type_code=d.type_code";
            //sqlStr += " where a.stock_name like '%" + transDTO.CodeStr + "%'";
            sqlStr += " where a.type_code in (select type_code from rs_check_point where stock_no='" + transDTO.CodeStr + "')";
            sqlStr += @" order by a.type_code";
            string connStr = "Data Source=ttdata;user id=ttdata;password=ttdata789";
            DataSet ds = OracleController.GetDataSet(connStr, sqlStr);
            ds.Tables[0].TableName = "bylaw";
            message = XMLHelper.DataSetToXML(ds);
            //LoggerHelper.Info(sqlStr);
            //LoggerHelper.Info("[" + transDTO.IP + "][发送更新数据！]");
            //FileStream MyFileStream = new FileStream("d://Bylaw.xml", FileMode.Create, FileAccess.Write);
            //byte[] tmp = (byte[])message;
            //MyFileStream.Write(tmp, 0, tmp.Length);
            //MyFileStream.Close();

            //sqlStr = @"select row_number() over( order by a.type_code,a.group_no,a.zwid) ""id_i"",a.type_code ""bylawCode_s""";
            //sqlStr += @",a.group_no ""groupNo_i"",b.zwmc ""postDesc_s"",point ""point_i""";
            //sqlStr += @"from rs_check_point a left join rs_zw b on a.zwid=b.zwid order by a.type_code,a.group_no,a.zwid";
            //connStr = "Data Source=ttdata;user id=ttdata;password=ttdata789";
            //ds = OracleController.GetDataSet(connStr, sqlStr);
            //ds.Tables[0].TableName = "CheckPoint";
            //tmp = XMLHelper.DataSetToXML(ds);
            //LoggerHelper.Info("[" + transDTO.IP + "][更新数据！2]");
            //MyFileStream = new FileStream("d://CheckPoint.xml", FileMode.Create, FileAccess.Write);
            //MyFileStream.Write(tmp, 0, tmp.Length);
            //MyFileStream.Close();

        }

        private void UpdateCheckPointData(object transObj, RedirectModel redirectModel, out object message)
        {

            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            string[] data = transDTO.CodeStr.Split('|');
            LoggerHelper.Info("[" + transDTO.IP + "][下载考核岗位数据...]");
            string sqlStr = @"select row_number() over( order by a.type_code,a.group_no,a.zwid) ""id_i"",a.type_code ""bylawCode_s""";
            sqlStr += @",a.group_no ""groupNo_i"",b.zwmc ""postDesc_s"",point ""point_i""";
            sqlStr += @"from rs_check_point a left join rs_zw b on a.zwid=b.zwid";
            //sqlStr += @" left join rs_check_type2 c on a.type_code=c.type_code";
            sqlStr += @" where a.stock_no='"+data[1]+"'";
            sqlStr += @" order by a.type_code,a.group_no,a.zwid";
            string connStr = "Data Source=ttdata;user id=ttdata;password=ttdata789";
            DataSet ds = OracleController.GetDataSet(connStr, sqlStr);
            ds.Tables[0].TableName = "CheckPoint";
            message = XMLHelper.DataSetToXML(ds);
            //LoggerHelper.Info(sqlStr);
        }
        private void DownloadDeptConfig(object transObj, RedirectModel redirectModel, out object message)
        {

            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            LoggerHelper.Info("[" + transDTO.IP + "][下载考核部门数据...]");
            string sqlStr = @"select id_i ""id_i"",deptNo_s ""deptNo_s"",deptName_s ""deptName_s"" from android_dept";
            string connStr = "Data Source=ttdata;user id=ttdata;password=ttdata789";
            DataSet ds = OracleController.GetDataSet(connStr, sqlStr);
            ds.Tables[0].TableName = "Dept";
            message = XMLHelper.DataSetToXML(ds);
        }

        private void DownloadStockConfig(object transObj, RedirectModel redirectModel, out object message)
        {

            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            LoggerHelper.Info("[" + transDTO.IP + "][下载店铺配置数据...]");
            string sqlStr = @"select id_i ""id_i"",stockNo_s ""stockNo_s"",stockName_s ""stockName_s""";
            sqlStr += @",ssid_s ""ssid_s"",pwd_s ""pwd_s"",ip_s ""ip_s"",gateway_s ""gateway_s""";
            sqlStr += @",serverIP_s ""serverIP_s"",serverPort_s ""serverPort_s"" from android_stock_config";
            sqlStr += @" where deviceNo_s='" + transDTO.CodeStr + "'";
            string connStr = "Data Source=ttdata;user id=ttdata;password=ttdata789";
            DataSet ds = OracleController.GetDataSet(connStr, sqlStr);
            ds.Tables[0].TableName = "Stock";
            message = XMLHelper.DataSetToXML(ds);
        }

        private void PrintBylawData(object transObj, RedirectModel redirectModel, out object message)
        {
            CompactFormatter.TransDTO transDTO = transObj as CompactFormatter.TransDTO;
            string[] data = transDTO.CodeStr.Split('|');    //worker_no|stock_no
            if (data.Length < 2)
            {
                message = "找不到数据！";
                return;
            }

            string sqlstr = "select bmmc,xm,khrq,pad_id,type_code,type_name,ltrim(max(sys_connect_by_path(zw_desc, ';')), ';') as post";
            sqlstr += " from (select bmmc,xm,khrq,pad_id,type_code,type_name,zw_desc,rnFirst";
            sqlstr += ",lead(rnFirst) over(partition by bmmc,xm,khrq,pad_id,type_code,type_name order by rnFirst) rnNext";
            sqlstr += " from (select f.bmmc,e.xm,a.khrq,a.pad_id,a.type_code,b.type_name,d.zwmc||'['||decode(c.is_onduty,'01','当值','全体')||']('||c.point||')' zw_desc";
            sqlstr += ",row_number() over(order by f.bmmc,e.xm,a.khrq,a.pad_id, type_code,type_name) rnFirst";
            sqlstr += " from rs_jx_pad a left join rs_check_type2 b on a.type_code=b.type_code";
            sqlstr += " inner join rs_check_point c on a.type_code=c.type_code and a.group_no=c.group_no";
            sqlstr += " and c.stock_no='" + data[2] + "'";
            sqlstr += " left join rs_zw d on c.zwid=d.zwid";
            sqlstr += " left join rs_ygjbzl e on a.czygh=e.gh";
            sqlstr += " left join rs_bm f on a.bmid=f.bmid";
            sqlstr += " where a.khrq=to_char(sysdate,'yyyymmdd')";
            sqlstr += " and a.czygh='" + data[0] + "'";
            sqlstr += " and a.bmid='" + data[1] + "'";
            sqlstr += " order by f.bmmc,e.xm,a.khrq,a.pad_id, a.type_code) tmpTable1) tmpTable2 start with rnNext is null";
            sqlstr += " connect by rnNext = prior rnFirst group by bmmc,xm,khrq,pad_id,type_code,type_name";
            PrintHelper.GetInstance().PrintReport(ConfigurationManager.ConnectionStrings["ttdataConnStr"].ToString()
                        , sqlstr, "query1", "D://MatServer//ttdata_jx_pad.frx", Config.Instance.sysInfo.officePrintName);
            message = "SUCCESS";

        }

    }
    public class SysInfo
    {
        public string name { get; set; }
        public string version { get; set; }
        public string wince_path { get; set; }
        public string pc_path { get; set; }
        public string stock_name { get; set; }
        public string stock_no { get; set; }
        public string server_ip { get; set; }
        public int server_port { get; set; }
        public int maxSessionTimeout { get; set; }
        public string remoteServer { get; set; }
        public int maxListener { get; set; }
        public string printName { get; set; }
        public string officePrintName { get; set; }
        public string ttspaServer { get; set; }
        public bool recordCodeStr { get; set; }
        public bool recordOutStr { get; set; }
        public bool recordTestStr { get; set; }
    }
}
