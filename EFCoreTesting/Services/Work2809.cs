using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public interface IContext
    {

    }

    public class Work2809 : IDisposable
    {
        private Context context;

        public Work2809(Context context)
        {
            this.context = context;
        }

        public Address GetAddressWithFilterUser(int id)
        {
            var adr = context.Addresses.Where(i => i.Id == id).First();

            context.Entry(adr).Collection(i => i.Users).Query().Where(x => x.Id > 5).Load();
            return adr;
        }

        public Address GetAddressWithUser()
        {
            var adr = context.Addresses.Include(i => i.Users).First();
            return adr;
        }
        public IEnumerable<User> GetAddressWithUser2()
        {
            var adr = context.Users.Include(p => p.Address).AsQueryable();
            return adr;
        }

        public void AddUser(string name, string lastName, int Age)
        {
            var address = context.Addresses.First();
            var user = new User {Age = Age, FirstName = name, LastName = lastName, IsMale = true, BirthDay = new DateTime(2012,12, 23), Address = address };
            context.Add(user);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
