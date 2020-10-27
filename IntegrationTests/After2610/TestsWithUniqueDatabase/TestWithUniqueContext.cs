using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.After2610.TestsWithUniqueDatabase
{
    public class TestWithUniqueContext
    {
        [Fact]
        public async void TestDemo()
        {
            using (var context = await Context2710.ReturnContext())
            {
                var res = context.Users.FirstOrDefault();

                Assert.Equal("Иван", res.FirstName);
            }
        }

    }
}
