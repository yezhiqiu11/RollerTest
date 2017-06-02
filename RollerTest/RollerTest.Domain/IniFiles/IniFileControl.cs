using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerTest.Domain.IniFiles
{
    public class IniFileControl
    {
        private static IniFileControl instance;
        private static readonly object locker = new object();
        public static System.Timers.Timer controlTimer = new System.Timers.Timer(1000);
        private RollerTime rollerTime = new RollerTime();
        private IniFileControl() {
            controlTimer.Elapsed += ControlTimer_Elapsed;
            controlTimer.Enabled = false;
        }

        public static IniFileControl GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new IniFileControl();
                    }
                }
            }
            return instance;
        }
        private void ControlTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {     
            Profile.G_TestTime1 = rollerTime.TimeData1;
            Profile.G_TestTime2 = rollerTime.TimeData2;
            Profile.G_TestTime3 = rollerTime.TimeData3;
            Profile.G_TestTime4 = rollerTime.TimeData4;
            Profile.G_TestTime5 = rollerTime.TimeData5;
            Profile.G_TestTime6 = rollerTime.TimeData6;
            Profile.G_TestTime7 = rollerTime.TimeData7;
            Profile.G_TestTime8 = rollerTime.TimeData8;
            Profile.G_TestTime9 = rollerTime.TimeData9;
            Profile.G_TestTime10 = rollerTime.TimeData10;
            Profile.G_TestTime11 = rollerTime.TimeData11;
            Profile.G_TestTime12 = rollerTime.TimeData12;
            IniFiles.Profile.Saveprofile();
        }
        public bool TimerState()
        {
            return controlTimer.Enabled;
        }
        public void OpenTimer()
        {
            controlTimer.Enabled = true;
        }
        public void CloseTimer()
        {
            controlTimer.Enabled = false;
        }
        public ReadIniModel ReadInifile()
        {
            IniFiles.Profile.LoadProfile();
            ReadIniModel readiniModel = new ReadIniModel
            {
                TestTime1 = Profile.G_TestTime1,
                TestTime2 = Profile.G_TestTime2,
                TestTime3 = Profile.G_TestTime3,
                TestTime4 = Profile.G_TestTime4,
                TestTime5 = Profile.G_TestTime5,
                TestTime6 = Profile.G_TestTime6,
                TestTime7 = Profile.G_TestTime7,
                TestTime8 = Profile.G_TestTime8,
                TestTime9 = Profile.G_TestTime9,
                TestTime10 = Profile.G_TestTime10,
                TestTime11 = Profile.G_TestTime11,
                TestTime12 = Profile.G_TestTime12

            };

            return readiniModel ;
        }


    }
}
