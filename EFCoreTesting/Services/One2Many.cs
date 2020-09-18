using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class One2Many
    {

        private Context connect;

        public One2Many(Context connect)
        {
            this.connect = connect;
        }


        public IEnumerable<Address> GetUsersWithAddresses()
        {
            return connect.Addresses.Include(a => a.Users);
        }


        public IEnumerable<Address> UpdateAddressWithUsers(IEnumerable<Address> addresses)
        {
            connect.Addresses.UpdateRange(addresses);
            connect.SaveChanges();
            return connect.Addresses;
        }

        public IEnumerable<Address> UpdateAddressWithUsers(Address addresses)
        {
            connect.Addresses.Update(addresses);
            connect.SaveChanges();
            return connect.Addresses;
        }

    }
}
