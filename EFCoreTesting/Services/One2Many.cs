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


#warning что происходит с данными, которые не включались в модель во вьюхе? Они обнуляются? Если да, как сделать так, чтобы обновлялись только изменившиеся данные?
        public IEnumerable<Address> UpdateAddressWithUsers(IEnumerable<Address> addresses)
        {
            connect.Addresses.UpdateRange(addresses);
            connect.SaveChanges();
            return connect.Addresses;
        }
    }
}
