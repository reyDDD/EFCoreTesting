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

        public User GetUserWithoutAddress()
        {
            var usr = context.Users.FirstOrDefault();
            return usr;
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
            var strategy = context.Database.CreateExecutionStrategy();

            var address = context.Addresses.First();
            var user = new User { Age = Age, FirstName = name, LastName = lastName, IsMale = true, BirthDay = new DateTime(2012, 12, 23), Address = address };
            context.Add(user);


            var user2 = new User { Age = Age + 10, FirstName = name + " нормально так", LastName = lastName + " фамилия", IsMale = true, BirthDay = new DateTime(2014, 11, 29), Address = address };
            context.Add(user2);


            strategy.ExecuteInTransaction(context,
        operation: context =>
        {
            context.SaveChanges(acceptAllChangesOnSuccess: false); //параметр позволяет избежать изменения состояния на неизмененное, если выполнена операция SaveChanges
        },
        verifySucceeded: con => con.Users.AsNoTracking().Any(b => b.Age == Age && b.FirstName == lastName)); // функция вызывается при возникновении временной ошибки во время фиксации транзакции.  Похоже, проверяет, были ли внесены измения в базу и если да, повторно не добавит

            context.ChangeTracker.AcceptAllChanges();



        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
