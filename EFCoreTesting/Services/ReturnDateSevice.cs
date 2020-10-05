using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
   
    public class ReturnDateSevice
    {

        public void Update(object obj = null)
        {
            Sobitiye.Invoke(DateTime.Now);
        }

        public event Func<DateTime, Task> Sobitiye;



        public void StartTimer()
        {
            TimerCallback timerCallback = new TimerCallback(Update);
            Timer timer = new Timer(timerCallback, 0, 0, 2000);
        }
    }

}
