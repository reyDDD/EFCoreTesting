using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Model2810
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public string PriceBlack
        {
            get { return Price.ToString(); }
            set { Price = Convert.ToDecimal(value); }
        }
    }
}
