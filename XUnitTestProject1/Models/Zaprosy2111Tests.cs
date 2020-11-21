using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Models
{
    public class Zaprosy2111Tests
    {
        private Context context;
        public Zaprosy2111Tests()
        {
            context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;").Options);
        }
        [Fact]
        public void TestUpdate()
        {
            Zaprosy2111 zaprosy2111 = new Zaprosy2111(context);
            zaprosy2111.UpdateData(70, "Кременчук", "Друже Бобер");

            User? user = context.Users.Include(a => a.Address).Where(i => i.Id == 70).FirstOrDefault();

            Assert.Equal("Друже Бобер", user.FirstName);
            Assert.Equal("Кременчук", user.Address.City);
        }
    }
}
