using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
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



        [Fact]
        public void TestDeleteRow()
        {
            using (var connect = new Context(TestDbContextOptions.CreateOptions()))
            {
                //размещение
                var vozvrat2909 = new Vozvrat2909(connect);
                vozvrat2909.Seed();
                int countStart = connect.Users.Count();

                //действие
                vozvrat2909.DeleteUser();
                int countEnd = connect.Users.Count();

                //утверждение
                Assert.True((countStart - countEnd) == 1);
            }
        }

        [Fact]
        public void TestNotDeleteRowWhereIdNull()
        {
            using (var connect = new Context(TestDbContextOptions.CreateOptions()))
            {
                //размещение
                var vozvrat2909 = new Vozvrat2909(connect);
                vozvrat2909.Seed();
                int countStart = connect.Users.Count();

                //действие
                vozvrat2909.DeleteUser(111);

                int countEnd = connect.Users.Count();

                //утверждение
                Assert.True((countStart - countEnd) == 0);
            }
        }

        [Fact]
        public void TestReturnProperty()
        {
            //размещение
            var mock = new Mock<IVozvrat2909>();
            mock.Setup(m => m.Work2909()).Returns(new Address { City = "Gonduras", Country = "tudage" });
            var control = new DALController(mock.Object);

            //действие
            control.SetCountry();
 

            //утверждение
            Assert.True("tudage" == control.Country);

        }
    }
}
