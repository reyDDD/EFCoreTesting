using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class AutoSuplier
    {
        public int Id { get; set; }
        public string DilerName { get; set; }
        public IEnumerable<Auto> Autos { get; set; }
    }
}
