using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
