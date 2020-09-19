using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
