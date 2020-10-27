using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public interface IWork2510ModelRepo2
    {
        Task<User> GetUser(long id);
        Task<User> GetUserAtData(User user);
    }

    public class Work2510ModelRepo2 : IWork2510ModelRepo2
    {
        private IContext2510 context2510;

        public Work2510ModelRepo2(IContext2510 context2510)
        {
            this.context2510 = context2510;
        }

        public async Task<User> GetUser(long id)
        {
            return await context2510.Users.Include(m => m.Address).Where(m => m.Id == id).FirstOrDefaultAsync();
        }


        public async Task<User> GetUserAtData(User user)
        {
            return await context2510.Users.Include(m => m.Address).Where(m => m.FirstName == user.FirstName && m.LastName == user.LastName && m.Age == user.Age && m.IsMale == user.IsMale).FirstOrDefaultAsync();
           // return await context2510.Users.Include(m => m.Address).Where(m => m.FirstName == user.FirstName && m.LastName == user.LastName && m.BirthDay == user.BirthDay && m.Age == user.Age && m.IsMale == user.IsMale).FirstOrDefaultAsync();
        }
    }
}
