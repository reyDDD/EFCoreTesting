using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediatr
{
    public class EventForMediatorConcrete : EventForMediatorAbstract
    {
        public EventForMediatorConcrete(IMediator<IEventForMediator> mediator): base(mediator)
        {
        }
        public override string Notify(string text)
        {
            return text + " вау йеху";
        }

        public override string Send()
        {
            return Mediator.Send(this);
        }
    }
}
