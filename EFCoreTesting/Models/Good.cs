using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Good
    {
        public decimal Price { get; set; }
        public string PriceSave 
        {
            get { return Price.ToString(); }
            set { Price = Convert.ToDecimal(value); }
        }

        public string Name { get; set; }
    }
}
