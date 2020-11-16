using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class Service1611
    {
        private Context context;

        public Service1611(Context context)
        {
            this.context = context;
        }

        public Address UpdateCity(int id, string city)
        {
            Address address = context.Addresses.Find(id);
            address.City = city;
            context.SaveChanges();
            return address;
        }
    }
}
