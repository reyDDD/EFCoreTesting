using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Model1511Tests
    {
        [Fact]
        public void TestEachOther()
        {
            var options = ConnOptionsForModel1511.GetOptions<Context>();
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                var res1 = model.GetUser1(10);
                var res2 = model.GetUser2(10);
                Assert.Equal(res1, res2);
            }
        }
    }
}
