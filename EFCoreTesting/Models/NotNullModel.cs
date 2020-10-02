using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class NotNullModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Street { get; set; } 


        public IEnumerable<House> House { get; set; }

    }
}
