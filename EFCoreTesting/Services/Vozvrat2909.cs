using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class Vozvrat2909
    {
        private Context connect;
        public Vozvrat2909(Context connect)
        {
            this.connect = connect;
        }

        public Address Work2909()
        {
            var address = connect.Addresses.FirstOrDefault();
            connect.Entry(address).Collection(i => i.Users).Query().Where(i => i.Age > 20).Load();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            var addresse = connect.Addresses.Update(address);
            connect.SaveChanges();
            return addresse.Entity;
        }

        public Address UpdateAddressU(Address address, Address original)
        {
            if (original != null)
            {
                original.City = address.City;
                original.Country = address.Country;

            }
            var addresse = connect.Addresses.Update(original);
            connect.SaveChanges();
            return addresse.Entity;
        }
    }
}
