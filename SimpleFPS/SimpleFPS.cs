using System;

namespace aiRobots
{
    public class SimpleFPS_Args : System.EventArgs
    {
        public double FPS;
    }

    // fixed time frame number method
    public class SimpleFPS
    {

        public delegate void FPSTool_EventHandler(object sender, SimpleFPS_Args e);

        public SimpleFPS(int interval_sec = 1)
        {
            this.interval_sec = interval_sec;
            this.aTimer = new System.Timers.Timer(this.interval_sec * 1000);
            this.aTimer.Elapsed += OnTimedEvent;
            this.aTimer.AutoReset = true;
            this.aTimer.Enabled = true;
        }

        public event FPSTool_EventHandler FPSUpdated = delegate { };

        public double FPSUpdate(int Count = 1)
        {
            this.fps_count += Count;
            return this.fps;
        }
        public double FPS { get => fps; }


        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.fps = (double)this.fps_count / this.interval_sec;
            this.fps_count = 0;

            SimpleFPS_Args args = new SimpleFPS_Args();
            args.FPS = this.fps;
            this.FPSUpdated(this, args);
        }

        private double fps;
        private int fps_count = 0;
        private double interval_sec;
        private System.Timers.Timer aTimer;

    }

    // the average sampling time method
    public class AverageFPS
    {
        public AverageFPS(int average_number = 10)
        {
            this.avg_num = average_number;
        }
        public double FPS { get => fps; }
        public double FPSUpdate()
        {
            TimeSpan sp = DateTime.Now - this.check_time;
            this.check_time = DateTime.Now;
            this.avg_duration -= this.avg_duration / avg_num;
            this.avg_duration += sp.TotalSeconds / avg_num;
            this.fps = 1.0 / this.avg_duration;
            return this.fps;
        }

        private double avg_duration = 0.0;
        private int avg_num;
        private DateTime check_time = DateTime.Now;
        private double fps = 0.0;
    }
}