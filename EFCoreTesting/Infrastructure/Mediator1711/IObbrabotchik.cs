using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1711
{
    public interface IObbrabotchik<X, Y> where X : class 
    {
        Y Pusk(X param);
    }
}
