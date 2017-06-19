using RollerTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using Hangfire;

namespace RollerTest.WebUI.ExternalProgram
{
    public class CdioControl
    {
        private static CdioControl instance;
        private static readonly object locker = new object();
        public static System.Timers.Timer controlTimer = new System.Timers.Timer(1000);
        private MoterState moterState = new MoterState();
        private CdioMethod cdioMethod = new CdioMethod();
        private CdioControl()
        {
            controlTimer.Elapsed += ControlTimer_Elapsed;
            controlTimer.Enabled = false;
        }
        public static CdioControl GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new CdioControl();
                    }
                }
            }
            return instance;
        }
        public void MonitorMoto()
        {
            if (moterState.IsMotoRunning == false)
            {
                cdioMethod.MotoStop();
            }
            else
            {
                if (moterState.MotoREV == 0)
                {
                    cdioMethod.MotoRun(0);
                }
                else
                {
                    cdioMethod.MotoRun(1);
                }
            }
        }

        private void ControlTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MonitorMoto();
        }
        public string InitMoto()
        {
            return cdioMethod.InitDio();
        }
        public void MotoStop()
        {
            cdioMethod.MotoStop();
        }
        public void MotoRun(int REV)
        {
            cdioMethod.MotoRun(REV);
        }
        public bool TimerState()
        {
            return controlTimer.Enabled;
        }
        public MoterState getMotoState()
        {
            return this.moterState;
        }
        public void OpenTimer()
        {
            controlTimer.Enabled = true;
        }
        public void CloseTimer()
        {
            controlTimer.Enabled = false;
        }
        public void setMotoRunning()
        {
            this.moterState.MotoREV = 0;
            this.moterState.IsMotoRunning = true;
        }
        public void setMotoStopping()
        {
            this.moterState.IsMotoRunning = false;
        }
        public void setMotoRunningREV()
        {
            this.moterState.MotoREV = 1;
            this.moterState.IsMotoRunning = true;

        }

    }
}