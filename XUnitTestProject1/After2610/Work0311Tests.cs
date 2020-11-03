using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace XUnitTestProject1.After2610
{
    public class Work0311Tests
    {
        [Fact]
        public async void TestAddData()
        {
            var conn = new Context(UniqueContextOptionsForTesting.OptionsForContext());

            conn.Addresses.Add(new Address { City = "Gorod", Country = "Strana" });
            await conn.SaveChangesAsync();
            var count = await conn.Addresses.CountAsync();
            Assert.True(count > 0);
        }

        [Fact]
        public async void TestFactDeleteData()
        {
            var conn = new Context(UniqueContextOptionsForTesting.OptionsForContext());

            var addr = conn.Addresses.Add(new Address { City = "Gorod", Country = "Strana" });
            await conn.SaveChangesAsync();

            var expectedAddresses = conn.Addresses.Where(a => a.Id != addr.Entity.Id);
            var yes = conn.Addresses.Find(1);
            conn.Remove(yes);
            await conn.SaveChangesAsync();

            var actualAddress = await conn.Addresses.AsNoTracking().ToListAsync();
            Assert.Equal(expectedAddresses?.OrderBy(m => m.Id)?.Select(i=>i.Id),
                actualAddress?.OrderBy(m => m.Id)?.Select(i => i.Id));
        }
    }
}
