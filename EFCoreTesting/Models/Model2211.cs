using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Model2211
    {
        [NotMapped]
        public decimal Origin { get; set; }

        [DataType(DataType.Currency)]
        public string ForChange
        {
            get { return Origin.ToString(); }
            set { Origin = Convert.ToDecimal(value); }
        }
    }
}
