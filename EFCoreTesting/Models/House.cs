using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class House
    {
        public int Id { get; set; }

        [Required]
        public string Home { get; set; }


        public NotNullModel StreetData { get; set; }  
    }
}
