using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Auto
    {
        [Key]
        public long Id { get; set; }

        [Range(1, 3000, ErrorMessage = "Скорость авто может быть не более 300 км/час")]
        public decimal MaxSpeed { get; set; }

        [MinLength(3, ErrorMessage ="Название производителя состоит минимум из 3 символов")]
        public string Brand { get; set; }
    }
}
