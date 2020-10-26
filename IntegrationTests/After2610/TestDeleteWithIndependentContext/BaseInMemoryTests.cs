using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.After2610.TestDeleteWithIndependentContext
{
    public class BaseInMemoryTests
    {

        [Fact]
        public async void TestDeleteData()
        {
            var context = await new ConnToMemory().GetContext();

            List<User> listUser = await context.Users.AsNoTracking().ToListAsync();
            
            var user = await context.Users.Where(i=>i.Id == 1).FirstOrDefaultAsync();
            List<User> listUserWithoutOne = default;

            if (user != null)
            {
                listUserWithoutOne = listUser.Where(i => i.Id != user.Id).ToList();
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            

            var listAfterRemove = await context.Users.AsNoTracking().ToListAsync();

            Assert.Equal(listUserWithoutOne.OrderBy(i=>i.Id).Select(m=>m.FirstName),
               listAfterRemove.OrderBy(i => i.Id).Select(m => m.FirstName)) ;
        }
    }
}
