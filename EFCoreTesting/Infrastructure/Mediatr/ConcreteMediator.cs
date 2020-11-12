using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediatr
{
    public class ConcreteMediator : IMediator<IEventForMediator>
    {
        public string Send(IEventForMediator eventForMediator)
        {
            //тут реализую на экземпляре репозитария добавление данных в базу

            //а затем вызываю метод из класса-события
           return eventForMediator.Notify("работа по добавлению в базу выполнена");
        }
    }
}
