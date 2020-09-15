using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Services
{
    public class WorkOne2Many
    {
        private Context context;

        public WorkOne2Many(Context context)
        {
            this.context = context;
        }

        public void AddOrUpdate(User user, User userOrigin = null, Address addressOrigin = null)
        {

            if (user.Id == 0)
            {
                if (user.Address?.City == null && user.Address?.Country == null && user.Address?.Id == 0)
                {
                    user.Address = null;
                }
                context.Users.Add(user);
            }
            else if (user.Id != 0)
            {
                userOrigin = context.Users.Find(user.Id);
                userOrigin.FirstName = user.FirstName;
                userOrigin.LastName = user.LastName;
                userOrigin.Age = user.Age;

                if (user.Address.Id != 0)
                {
                    addressOrigin = context.Addresses.Find(user.Address.Id);
                }
                else
                {
                    context.Attach<Address>(addressOrigin);
                    addressOrigin.Country = user.Address.Country;
                    addressOrigin.City = user.Address.Country;
                }
                user.Address = addressOrigin;
                context.Users.Add(user);
            }
            context.SaveChanges();

        }

        public IEnumerable<User> ListUser()
        {
            try
            {
                var res = context.Users.Include(a => a.Address).ToList();
                return res;
            }
            catch (Exception ex)
            {
                return new List<User> { new User { FirstName = "Masha" } };
            }  
        }
    }
}
