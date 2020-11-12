using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediatr
{
    public class EventForMediatorConcrete : IEventForMediator
    {
        public IMediator<EventForMediatorConcrete> Mediator { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }


        public EventForMediatorConcrete(IMediator<EventForMediatorConcrete> mediator)
        {
            Mediator = mediator;
        }


        public string Notify(string text)
        {
            return text + " вау йеху";
        }

        public string Send()
        {
            return Mediator.Send(this);
        }
    }
}
