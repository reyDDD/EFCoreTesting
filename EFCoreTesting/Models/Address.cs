using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [JsonIgnore]
        public IEnumerable<User> Users { get; set; }
    }
}
