using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class WorkRelation
    {
        private Context connect;
        public WorkRelation(Context connect)
        {
            this.connect = connect;
        }

        public void AddUser(User user)
        {
            connect.Users.Add(user);
            connect.SaveChanges();
        }

        public User GetUser(long id)
        {
            return connect.Users.Where(idsn => idsn.Id == id).Include(c => c.Address).First();
        }

        public User UpdateAddressThroughUser(User changeUser, User originUser = null)
        {
            connect.Attach(changeUser);
            connect.SaveChanges();
            return changeUser;
        }
    }
}
