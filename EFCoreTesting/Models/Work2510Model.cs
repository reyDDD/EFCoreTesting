using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public interface IWork2510Model
    {
        Task<User> GetUser(long id);
        Task UpdateUserAndAddress(User user);
    }

    public class Work2510Model : IWork2510Model
    {
        private Context Connect { get; }

        public Work2510Model(Context context)
        {
            Connect = context;
        }

        public async Task<User> GetUser(long id)
        {
            return await Connect.Users.Include(m => m.Address).Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateUserAndAddress(User user)
        {
           Address addres = await Connect.Addresses.FindAsync(user.Address.Id);
            user.Address.City = addres.City;
            user.Address.Country = addres.Country;

            Connect.Entry(user).State = EntityState.Modified;
            await Connect.SaveChangesAsync();
        }
    }
}
