using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace ToDoList
{
    class TimerHandler
    {
        Label lbl_timer;
        TimeSpan time;
        Timer timer;
        SoundPlayer alarm;
        SoundPlayer ticker;
        public bool isRunning = false;

        public TimerHandler(Label theLbl_timer, Timer theTimer)
        {
            lbl_timer = theLbl_timer;
            timer = theTimer;
            time = new TimeSpan(1, 00, 00);
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            alarm = new SoundPlayer(ToDoList.Properties.Resources.aud_alarm);
            ticker = new SoundPlayer(ToDoList.Properties.Resources.aud_ticking);
        }

        public void StartTimer()
        {
            ticker.Play();
            isRunning = true;
            UpdateTimerLabel();
            timer.Start();
        }

        public void PauseTimer()
        {
            isRunning = false;
            timer.Stop();
            UpdateTimerLabel();
        }

        private void StopTimer()
        {
            alarm.Play();
            isRunning = false;
            timer.Stop();
            UpdateTimerLabel();
        }

        public void Tick()
        {            
            time = time.Subtract(new TimeSpan(0, 0, 1));
            CheckIfTimerEnded();
            UpdateTimerLabel();
        }

        private void CheckIfTimerEnded()
        {
            if (time == TimeSpan.Zero)
                StopTimer();
        }

        private void UpdateTimerLabel()
        {
            lbl_timer.Text = time.Minutes.ToString("D2") + ":" + time.Seconds.ToString("D2");
        }
    }
}
