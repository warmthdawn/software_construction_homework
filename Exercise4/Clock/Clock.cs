using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    public class Clock
    {

        public TimeSpan TickInterval { get; set; }

        private List<Tuple<string, DateTime>> _alarmTimes;

        public bool IsRunning { get; set; }

        private DateTime? lastTick;

        public Clock(TimeSpan tickInterval)
        {
            TickInterval = tickInterval;
            _alarmTimes = new List<Tuple<string, DateTime>>();
            IsRunning = false;
        }

        public Clock() : this(TimeSpan.FromSeconds(1)) { }


        public event EventHandler<ClockEventArgs> Tick;
        public event EventHandler<ClockEventArgs> Alarm;
        public event EventHandler ClockStart;
        public event EventHandler ClockStop;

        public void AddAlarm(DateTime time, string message)
        {
            if (time <= DateTime.Now)
            {
                throw new ArgumentException("闹钟的时间小于当前时间。");
            }
            _alarmTimes.Add(new Tuple<string, DateTime>(message, time));
        }

        public async void Start()
        {
            lastTick = null;
            IsRunning = true;
            ClockStart?.Invoke(this, EventArgs.Empty);
            while (IsRunning)
            {
                Tick?.Invoke(this, new ClockEventArgs(DateTime.Now, "闹钟滴答"));

                foreach (var (message, time) in _alarmTimes)
                {
                    if (DateTime.Now > time)
                    {
                        Alarm?.Invoke(this, new ClockEventArgs(time, message));
                    }
                }

                _alarmTimes.RemoveAll(t => DateTime.Now > t.Item2);


                TimeSpan delayFromLast = lastTick.HasValue ? DateTime.Now - lastTick.Value : TickInterval;
                lastTick = DateTime.Now;
                await Task.Delay(TickInterval * 2 - delayFromLast);
            }

            ClockStop?.Invoke(this, EventArgs.Empty);
        }

        public void Stop()
        {
            this.IsRunning = false;
        }
    }

    public class ClockEventArgs : EventArgs
    {
        public ClockEventArgs(DateTime time, string message)
        {
            Time = time;
            Message = message;
        }

        public DateTime Time { get; set; }
        public string Message { get; set; }
    }

}
