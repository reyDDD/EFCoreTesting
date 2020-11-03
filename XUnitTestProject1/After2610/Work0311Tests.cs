using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;

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
    }
}
