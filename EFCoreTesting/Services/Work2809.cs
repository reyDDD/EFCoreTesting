using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class Work2809
    {
        private Context context;

        public Work2809(Context context)
        {
            this.context = context;
        }

        public Address GetAddressWithFilterUser(int id)
        {
            var adr = context.Addresses.Where(i => i.Id == id).First();
         
                 context.Entry(adr).Collection(i => i.Users).Query().Where(x => x.Id > 5).Load();
            return adr;
        }
    }
}
