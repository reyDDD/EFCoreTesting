using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediatr
{
    public abstract class EventForMediatorAbstract : IEventForMediator
    {
        public IMediator<IEventForMediator> Mediator { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public EventForMediatorAbstract(IMediator<IEventForMediator> mediator)
        {
            Mediator = mediator;
        }

        public abstract string Notify(string text);
        public abstract string Send();
    }
}
