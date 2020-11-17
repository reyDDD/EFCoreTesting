using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1711
{
    public interface IMedi<T> where T : class
    {
        public EndClass EndClass { get; set; }
        EndClass Work(T exemplar);
    }
}
