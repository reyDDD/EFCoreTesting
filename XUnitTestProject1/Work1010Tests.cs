using EFCoreTesting.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class Work1010Tests
    {

        [Fact]
        public void ReturnNullOr()
        {
            Work1010 work1010 = new Work1010();
            var res = work1010.ReturnUserById(10000);


            var otvet = Assert.IsType<ContentResult>(res);
            Assert.Equal("this user not found", otvet.Content);
        }
    }
}
