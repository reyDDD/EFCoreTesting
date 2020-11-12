using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediatr
{
    public interface IEventForMediator
    {
        IMediator<IEventForMediator> Mediator { get; set; }
        string Name { get; set; }
        string Family { get; set; }
        string Country { get; set; }
        string Address { get; set; }
        string Notify(string text);
        string Send();
    }
}
