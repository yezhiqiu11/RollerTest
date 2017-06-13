using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.WebUI.IniFiles
{
    public class Profile
    {
        public static void LoadProfile()
        {
            string strpath = AppDomain.CurrentDomain.BaseDirectory;
            _file = new IniFile(strpath + "Cfg.ini");
            G_TestTime1 = _file.ReadString("CONFIG", "TestTime1", "00:00:00");
            G_TestTime2 = _file.ReadString("CONFIG", "TestTime2", "00:00:00");
            G_TestTime3 = _file.ReadString("CONFIG", "TestTime3", "00:00:00");
            G_TestTime4 = _file.ReadString("CONFIG", "TestTime4", "00:00:00");
            G_TestTime5 = _file.ReadString("CONFIG", "TestTime5", "00:00:00");
            G_TestTime6 = _file.ReadString("CONFIG", "TestTime6", "00:00:00");
            G_TestTime7 = _file.ReadString("CONFIG", "TestTime7", "00:00:00");
            G_TestTime8 = _file.ReadString("CONFIG", "TestTime8", "00:00:00");
            G_TestTime9 = _file.ReadString("CONFIG", "TestTime9", "00:00:00");
            G_TestTime10 = _file.ReadString("CONFIG", "TestTime10", "00:00:00");
            G_TestTime11 = _file.ReadString("CONFIG", "TestTime11", "00:00:00");
            G_TestTime12 = _file.ReadString("CONFIG", "TestTime12", "00:00:00");
        }
        public static void Saveprofile()
        {
            string strpath = AppDomain.CurrentDomain.BaseDirectory;
            _file = new IniFile(strpath + "Cfg.ini");
            _file.WriteString("CONFIG", "TestTime1", G_TestTime1);
            _file.WriteString("CONFIG", "TestTime2", G_TestTime2);
            _file.WriteString("CONFIG", "TestTime3", G_TestTime3);
            _file.WriteString("CONFIG", "TestTime4", G_TestTime4);
            _file.WriteString("CONFIG", "TestTime5", G_TestTime5);
            _file.WriteString("CONFIG", "TestTime6", G_TestTime6);
            _file.WriteString("CONFIG", "TestTime7", G_TestTime7);
            _file.WriteString("CONFIG", "TestTime8", G_TestTime8);
            _file.WriteString("CONFIG", "TestTime9", G_TestTime9);
            _file.WriteString("CONFIG", "TestTime10", G_TestTime10);
            _file.WriteString("CONFIG", "TestTime11", G_TestTime11);
            _file.WriteString("CONFIG", "TestTime12", G_TestTime12);
        }
        private static IniFile _file;

        public static string G_TestTime1 = "0.00:00:00";
        public static string G_TestTime2 = "0.00:00:00";
        public static string G_TestTime3 = "0.00:00:00";
        public static string G_TestTime4 = "0.00:00:00";
        public static string G_TestTime5 = "0.00:00:00";
        public static string G_TestTime6 = "0.00:00:00";
        public static string G_TestTime7 = "0.00:00:00";
        public static string G_TestTime8 = "0.00:00:00";
        public static string G_TestTime9 = "0.00:00:00";
        public static string G_TestTime10 = "0.00:00:00";
        public static string G_TestTime11 = "0.00:00:00";
        public static string G_TestTime12 = "0.00:00:00";
    }
}
