using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
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

 
        public string CodingText(string text)
        {
            HtmlEncoder encoder = HtmlEncoder.Create(UnicodeRanges.All);
            var res = encoder.Encode(text);
            return res;
        }

        public void CreateContextWithServiceProvider(IServiceProvider provider)
        {
            var contexta = new Context(provider.GetRequiredService<DbContextOptions<Context>>());
            contexta.Users.First();
        }
        public bool ContainsAny()
        {
            var result = context.Users.Any();
            return result;
        }

    }

    public class Model2111
    {
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public Model2111()
        {
            string config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("mySection").Value;
        }
    }
}
