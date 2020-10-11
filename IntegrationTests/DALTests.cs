using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class DALTests
    {

        [Fact]
        public void NewContextSingle()
        {

            using (var connect = new Context(TestDbContextOptions.CreateOptions()))
            {
                //размещение
                var vozvrat2909 = new Vozvrat2909(connect);
                vozvrat2909.Seed();

                //действие
                Address address = vozvrat2909.Work2909();

                //утверждение
                Assert.True(address.Users?.Count() == 2);
            }

        }


        [Fact]
        public void NewContextAddUser()
        {


            using (var connect = new Context(TestDbContextOptions.CreateOptions()))
            {
                //размещение
                var vozvrat2909 = new Vozvrat2909(connect);
                vozvrat2909.Seed();

                //действие
                vozvrat2909.AddUser();
                var address = connect.Users.Include(m => m.Address).ToList();

                //утверждение
                Assert.Equal(3, address.Count());
            }

        }


    }
}
