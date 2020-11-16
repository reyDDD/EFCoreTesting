using EFCoreTesting.Controllers.After2510;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.Controllers.After2510
{
    public class Work1611
    {
        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        public void RequiredParameter(int parameter)
        {
            Work1611Controller work = new Work1611Controller();
            var actionResult = work.Index(parameter);

            var viewresult = Assert.IsType<ViewResult>(actionResult);
            Assert.IsType<int>(viewresult.ViewData.Model);
            Assert.Equal(parameter, viewresult.ViewData.Model);

        }
    }
}
