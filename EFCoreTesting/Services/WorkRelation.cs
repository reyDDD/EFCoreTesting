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


        public void RemoveUserThroughAddress(long idUser, bool deleteWithAddress, bool deleteAddress)
        {
            var user = connect.Users.Where(i => i.Id == idUser).FirstOrDefault();
            if (deleteAddress)
            {
                Address address = connect.Addresses.Where(i => i.Id == user.AddressId).FirstOrDefault();
                connect.Remove<Address>(address);
            }
            else
            {
                if (deleteWithAddress)
                {
                    connect.Remove<User>(user);
                }
                else
                {
                    user.Address = null;
                    connect.Remove<User>(user);
                }
            }

            connect.SaveChanges();
        }
    }
}
