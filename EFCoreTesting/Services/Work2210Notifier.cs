using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace EFCoreTesting.Services
{
    public class Work2210Notifier
    {
        public async Task Update(int Age, string Name)
        {
            if (notiEvent != null)
            {
               await notiEvent.Invoke(Age, Name);
            }
        }

        public event Func<int, string, Task> notiEvent;

        private static Timer timer = new Timer();
        public void StartTimer()
        {
            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += ReturnData;
            timer.Enabled = true;
        }

        public async void ReturnData(object obj, ElapsedEventArgs e)
        {
           await Update(12, $"имя и {DateTime.Now}");
        }
    }
}
