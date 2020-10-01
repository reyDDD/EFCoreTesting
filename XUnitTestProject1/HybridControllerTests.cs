using EFCoreTesting.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class HybridControllerTests 
    {

        [Fact]
        public void IndexMethodTest()
        {
            //организация
            var controller = new HybridController();

            //действие
            var res = controller.Index();

            //утверждение
            var viewResult = Assert.IsType<ViewResult>(res); //проверка на тип возвращаемого экшном результата
            var model = Assert.IsAssignableFrom<string>(viewResult.ViewData.Model); //проверка на тип модели
            Assert.Equal("ogogo", model); //проверка содержимого модели
        }
    }
}
