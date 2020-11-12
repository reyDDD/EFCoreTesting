using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediatr
{
    public interface IMediator<in T> where T : IEventForMediator
    {
        string Send(IEventForMediator eventForMediator);
    }
}
