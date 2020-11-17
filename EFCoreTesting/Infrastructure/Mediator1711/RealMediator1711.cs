using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1711
{
    public class RealMediator1711 : IMedi<StartClass>
    {
       public  EndClass EndClass { get; set; }
 

        public EndClass Work(StartClass exemplar)
        {
            EndClass = new EndClass { Age = exemplar.Age, Name = exemplar.Name };

            return EndClass;
        }

     
    }
}
