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


        public Address Work2109()
        {
            return connect.Addresses.Include(p => p.Users).First();
        }
        public Address Work2109Update(Address address)
        {
            connect.Addresses.Update(address);
            connect.SaveChanges();
            return connect.Addresses.Include(p=> p.Users).Where(id => id.Id == address.Id).First();
        }
        public Address Work2309Get()
        {
            return connect.Addresses.Include(p => p.Users).First();
        }


        public IEnumerable<Address> GetAddressWithFilter1()
        {
            IEnumerable<Address> listAddress = connect.Addresses.ToArray();
            foreach (var adres in listAddress)
            {
                connect.Entry(adres).Collection(x => x.Users).Query().Where(x => x.Age > 22).Load();
            }
            return listAddress;
        }
        public IEnumerable<Address> GetAddressWithFilter2()
        {
            IEnumerable<Address> res = connect.Addresses.Include(x => x.Users).ToArray();
            foreach (var adres in res)
            {
                connect.Entry(adres).Collection(x => x.Users).Query().Where(x => x.Age > 22).Load();
            }
            return res;
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
