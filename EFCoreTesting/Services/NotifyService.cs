using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace EFCoreTesting.Services
{
    public class NotifyService
    {
        public event Func<int, string, Task<string>> uvedomlyalka;

        public async Task Start(int x, string y)
        {
            if (uvedomlyalka != null)
            {
                //выполняю некоторые действия с переменными и запускаю обработчик события с уже другими данными
                await uvedomlyalka.Invoke(x + 5, y + " Добавка");
            }
            
        }

        private static Timer timer = new Timer();
        public void StartTimer()
        {
            UpdateTimer();
        }

        public void UpdateTimer()
        {
            
            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += onTimeEvent;
            timer.Enabled = true;
        }

        public async  void onTimeEvent(Object source, ElapsedEventArgs e)
        {
            await Start(DateTime.Now.Minute, DateTime.Now.ToString());
        }
    }
}
