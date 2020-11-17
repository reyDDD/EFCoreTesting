using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1711
{
    public class Obrabotchik1711 : IObbrabotchik<StartClass, EndClass>
    {
        IMedi<StartClass> medi;
        public Obrabotchik1711(IMedi<StartClass> medi)
        {
            this.medi = medi;
        }
        public EndClass Pusk(StartClass param)
        {
            EndClass result = medi.Work(param);
            var megdu = Promegu(result);
            return result;
        }

        public string Promegu(EndClass result)
        {
            return new ExtraWork().ReturnName(result);
        }
    }
}
