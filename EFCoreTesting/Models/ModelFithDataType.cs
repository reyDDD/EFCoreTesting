using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class ModelFithDataType
    {
        public int Id { get; set; }

        [Display(Name = "DataType.Date")]
        [DataType(DataType.Date)]
        public DateTime Data1 { get; set; }

        [Display(Name = "DisplayFormat Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data2 { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [DataType(DataType.Currency)]
        public string Currency { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [DataType(DataType.Time)]
        public DateTime Time { get; set; }


        [DataType(DataType.Url)]
        public string Url { get; set; }

        [DataType(DataType.Upload)]
        public string Upload { get; set; }
    }
}
