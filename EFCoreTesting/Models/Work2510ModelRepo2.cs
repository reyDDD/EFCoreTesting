using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EFCoreTesting.Models
{
    public interface IWork2510ModelRepo2 :  IDisposable
    {
        Task<User> GetUser(long id);
        Task<User> GetUserAtData(User user);
        Task UpdateUser(User user);
        Task AddUserAsync(User user);
        Task<User> DeleteUserAsync(long id);
    }

    public class Work2510ModelRepo2 :  IWork2510ModelRepo2
    {
        private Context2510 context2510 { get; set; }

        public Work2510ModelRepo2(Context2510 context2510)
        {
            this.context2510 = context2510;
        }

        public void Dispose()
        {
            this.context2510 = null;
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

        public async Task UpdateUser(User user)
        {
          var res = context2510.Users.Update(user).State = EntityState.Modified;
           await context2510.SaveChangesAsync();
        }

        public async Task AddUserAsync(User user)
        {
            var res = await context2510.Users.AddAsync(user);
            await context2510.SaveChangesAsync();
        }

        public async Task<User> DeleteUserAsync(long id)
        {
            var user = await context2510.Users.FindAsync(id);
            context2510.Users.Remove(user);
            await context2510.SaveChangesAsync();
            return user;
        }

    }
}
