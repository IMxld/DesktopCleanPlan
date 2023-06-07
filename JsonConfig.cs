using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DesktopCleanPlan
{
    public static partial class DCPSettings
    {
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string style = "1";
        public static string startup = "0";
        public static string userid = "";
        public static string passwd = "";
        public static string cookie = "";
        public static string clientIp = "";
        public static string roomId = "";
        public static string roomName = "";
        public static string building = "";
    }

    public partial class AlarmClock
    {
        public AlarmClock() { }

        public string content = null;
        public int year = -1;
        public int month = -1;
        public int day = -1;
        public int hour = -1;
        public int minute = -1;
        public int second = -1;
        public List<DayOfWeek> weeks = null;
        public string tip = null;
        public AlarmClock nextClock = null;
    }

    static internal class JsonConfig
    {
        public static Dictionary<int, AlarmClock> clockDic = new Dictionary<int, AlarmClock>();

        public static void WriteJson()
        {
            JObject config = new JObject();
            JObject dcpSettings = new JObject();
            JObject dcpClock = new JObject();
            string configStr;

            dcpSettings.Add("folderPath", DCPSettings.folderPath);
            dcpSettings.Add("style", DCPSettings.style);
            dcpSettings.Add("startup", DCPSettings.startup);
            dcpSettings.Add("userid", DCPSettings.userid);
            dcpSettings.Add("passwd", ContentEncrypt.Encrypt(DCPSettings.passwd));
            dcpSettings.Add("cookie", DCPSettings.cookie);
            dcpSettings.Add("clientIp", DCPSettings.clientIp);
            dcpSettings.Add("roomId", DCPSettings.roomId);
            dcpSettings.Add("roomName", DCPSettings.roomName);
            dcpSettings.Add("building", DCPSettings.building);

            config.Add("DCPSettings", dcpSettings);
            configStr = Convert.ToString(config);
            File.WriteAllText(Application.StartupPath + "\\DCPconfig.json", configStr, Encoding.UTF8);
        }

        public static JObject ReadJson()
        {
            StreamReader file = File.OpenText(Application.StartupPath + "\\DCPconfig.json");
            JsonTextReader reader = new JsonTextReader(file);
            JObject config = (JObject)JToken.ReadFrom(reader);
            file.Close();
            file.Dispose();
            return config;
        }

        public static void DistributeData()
        {
            JObject config = ReadJson();
            DCPSettings.folderPath = config["DCPSettings"]["folderPath"].ToString();
            DCPSettings.style = config["DCPSettings"]["style"].ToString();
            DCPSettings.startup = config["DCPSettings"]["startup"].ToString(); 
            DCPSettings.userid = config["DCPSettings"]["userid"].ToString();
            DCPSettings.passwd = ContentEncrypt.Decrypt(config["DCPSettings"]["passwd"].ToString());
            DCPSettings.cookie = config["DCPSettings"]["cookie"].ToString();
            DCPSettings.clientIp = config["DCPSettings"]["clientIp"].ToString();
            DCPSettings.roomId = config["DCPSettings"]["roomId"].ToString();
            DCPSettings.roomName = config["DCPSettings"]["roomName"].ToString();
            DCPSettings.building = config["DCPSettings"]["building"].ToString();
        }
    }
}
