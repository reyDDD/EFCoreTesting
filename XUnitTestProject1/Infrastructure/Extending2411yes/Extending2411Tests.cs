using EFCoreTesting.Infrastructure.Extending2411yes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Infrastructure.Extending2411yes
{
    public class Extending2411Tests
    {
        [Fact]
        public void ReturnResult()
        {
            Extending2411 extending = new Extending2411();
            var res = extending.Workk("для начала");
            Assert.Equal("для начала dobavka", res);
        }
    }
}
