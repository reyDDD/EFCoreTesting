using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class Work1810Service
    {
        private Context connect;
        public Work1810Service(Context connect)
        {
            this.connect = connect;
        }
        public Address ReturAddressFirst()
        {
            var res = connect.Addresses.FirstOrDefault();
            return res;
        }

    }
}
