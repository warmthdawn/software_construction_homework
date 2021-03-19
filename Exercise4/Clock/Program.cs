using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            clock.Alarm += (s, e) => Console.WriteLine($"{e.Time} 的闹钟 {e.Message}");
            clock.Tick += (s, e) => Console.WriteLine($"闹钟滴答作响 {e.Time:hh:mm:ss}");
            clock.ClockStart += (s, e) => Console.WriteLine("闹钟启动");
            clock.ClockStop += (s, e) => Console.WriteLine("闹钟关闭");

            clock.AddAlarm(DateTime.Now.AddSeconds(5), "5秒之后的闹钟");
            clock.AddAlarm(DateTime.Now.AddSeconds(10), "10秒之后的闹钟");
            clock.AddAlarm(DateTime.Now.AddSeconds(30), "30秒之后的闹钟");

            clock.Start();

            Thread.Sleep(15 * 1000);
            clock.Stop();
            Thread.Sleep(20 * 1000);
        }
    }
}
