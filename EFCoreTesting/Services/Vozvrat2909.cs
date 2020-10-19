using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public interface IVozvrat2909
    {
        Address Work2909();
        Address GetAddressId(int id);
        Address UpdateAddress(Address address);
        Task<IQueryable<Address>> GetAddress();
        void AddUser();
        void UpdateAddress2(Address address);
        void DeleteUser();
        void DeleteUser(long id);
        void Seed();
    }

    public class Vozvrat2909 : IVozvrat2909
    {
        private Context connect;
        public Vozvrat2909(Context connect)
        {
            this.connect = connect;
        }


        public async Task<IQueryable<Address>> GetAddress()
        {
               return connect.Addresses.AsQueryable().Include(n=>n.Users);
        }

        public void UpdateAddress2(Address address)
        {
            connect.Addresses.Update(address);
            connect.SaveChanges();
        }

        public Address Work2909()
        {
            var address = connect.Addresses.FirstOrDefault();
            connect.Entry(address).Collection(i => i.Users).Query().Where(i => i.Age > 20).Load();
            return address;
        }

        public Address GetAddressId(int id)
        {
            var address = connect.Addresses.Include(m=>m.Users).Where(i =>i.Id == id).FirstOrDefault();
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

        public async void AddUser()
        {
            var addr = await connect.Addresses.FirstOrDefaultAsync();
            var user = new User { FirstName = "Michael", LastName = "Shumacher", Age = 53, BirthDay = new DateTime(2000, 05, 23), IsMale = true, Address = addr };

            await connect.Users.AddAsync(user);
            await connect.SaveChangesAsync();
        }
        public async void DeleteUser()
        {
            var user = await connect.Users.FirstOrDefaultAsync();
            connect.Users.Remove(user);
            await connect.SaveChangesAsync();
        }

        public async void DeleteUser(long id)
        {
            var user = await connect.Users.FindAsync(id);
            if (user != null)
            {
                connect.Users.Remove(user);
                await connect.SaveChangesAsync();
            }

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

        public async void Seed()
        {
            var addr = new Address { City = "Lviv", Country = "Ukraine" };

            List<User> list = new List<User>
             {
                 new User{FirstName = "Ivan", LastName ="Ivanov", Age = 33, BirthDay = new DateTime(2012, 05, 23), IsMale = true, Address = addr },
                 new User{FirstName = "Masha", LastName ="Piligrim", Age = 25, BirthDay = new DateTime(2002, 09, 14), IsMale = false , Address = addr }
             };
            connect.AddRange(list);
            await connect.SaveChangesAsync();
        }
    }
}
