using EFCoreTesting.Models;
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
    }
}
