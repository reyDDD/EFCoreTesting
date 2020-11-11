using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{

    public interface IWork1810Service
    {
        Address ReturAddressFirst();
    }
    public class Work1810Service : IWork1810Service
    {
        private Context connect;
        public Work1810Service(Context connect)
        {
            this.connect = connect;
        }
        public Address ReturAddressFirst()
        {
            var res = connect.Addresses.FirstOrDefault();
            connect.Entry(res).Collection(m => m.Users).Query().Where(i => i.Age > 12).Load();
            return res;
        }

    }
}
