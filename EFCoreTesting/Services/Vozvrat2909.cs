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

            var strategy = connect.Database.CreateExecutionStrategy();

            strategy.ExecuteInTransaction(connect,
                operation: cont => cont.SaveChanges(acceptAllChangesOnSuccess: false),
                verifySucceeded: cont => cont.Addresses.AsNoTracking().Any(b => b.Id == address.Id && b.City == address.City && b.Country == address.Country)
                );
            connect.ChangeTracker.AcceptAllChanges();

            return addresse.Entity;
        }

        public Address UpdateAddressU(Address address, Address original)
        {
            if (original != null)
            {
                original.City = address.City;
                original.Country = address.Country;

            }

            Address addresse = new Address();
       


            var strategy = connect.Database.CreateExecutionStrategy();

            strategy.ExecuteInTransaction(connect,
              operation: context =>
               {
                   addresse = connect.Addresses.Update(original).Entity;
                   connect.SaveChanges(acceptAllChangesOnSuccess: false);
               },
              verifySucceeded: connect => connect.Addresses.Include(i => i.Users).AsNoTracking().Any(i => i.City == original.City && i.Country == original.Country)
                );
            
            return addresse;
        }
    }
}
