using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class ModelForCheck
    {
        [Key]
        public long id { get; set; }

        [Required]
       // [Range(1, 100, ErrorMessage = "Число должно быть в диапазоне от 1 до 100 с разделителем - запятой")]
        [DataType(DataType.Currency, ErrorMessage = "В качестве разделителя десятичной части используйте запятую")]
        public string Price
        { get
            {
                return PriceWork.ToString();
            }
            set
            {
                PriceWork = Convert.ToDecimal(value, CultureInfo.CurrentCulture);
            } 
        }

        [NotMapped]
        private decimal PriceWork { get; set; }


        [Required]
        [StringLength(60,MinimumLength = 3)]
        [RegularExpression(@"^([A-Z])+?(\w+)", ErrorMessage = "Содержимое не соответствует регулярному выражению")]
        public string Name { get; set; }


    }
}
