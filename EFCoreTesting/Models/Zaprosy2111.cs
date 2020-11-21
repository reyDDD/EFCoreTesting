using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Zaprosy2111
    {
        private Context context;
        public Zaprosy2111(Context context)
        {
            this.context = context;
        }

        public IEnumerable<Address> ReturnTwoCollections()
        {
            var adr = context.Addresses.ToList();

            foreach (var item in adr)
            {
                context.Entry(item).Collection(u => u.Users).Query().Where(x => x.IsMale == true).Load();
            }
            return adr;
        }

        public void UpdateData(int idUser, string city, string name)
        {
            User? user = context.Users.Include(a=>a.Address).Where(id => id.Id == idUser ).First();
            if (user is null) new EntryPointNotFoundException();
            user.FirstName = name;
            user.Address.City = city;
            context.SaveChanges();
        }
    }
}
