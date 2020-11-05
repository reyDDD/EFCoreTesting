using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class TwoData
    {
        [DataType(DataType.Date)]
        public DateTime Data1 { get; set; }

        public DateTime Data2 { get; set; }
    }
}
