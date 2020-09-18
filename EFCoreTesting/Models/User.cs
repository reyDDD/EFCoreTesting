using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class User
    {
        public long Id { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage ="Имя не может быть длиннее 100 символов")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="В фамилии должно быть не менее 3 символов")]
        public string LastName { get; set; }
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        
        public bool IsMale { get; set; }
        public Address Address { get; set; }
    }
}
