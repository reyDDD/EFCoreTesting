using EFCoreTesting.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        [Fact]
        public void IndexMethod_TestModelState()
        {
            //организация
            var controller = new HybridController();
            controller.ModelState.AddModelError("ForError", "искусственно вызванная ошибка");
            var controllerModel = new HybridController.My();

            //действие
            var res = controller.Index(controllerModel);

            //утверждение
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(res); //проверка на тип возвращаемого экшна - ошибку 404
            Assert.IsType<SerializableError>(badRequestResult.Value); //проверка на тип возвращаемого значения

            var massError = false;
            var mass = (badRequestResult.Value as SerializableError);

            foreach (var item0 in mass)
            {
                if (item0.Key == "ForError")
                {
                    foreach (string item in (item0.Value as string[]))
                    {
                            if (item == "искусственно вызванная ошибка")
                            {
                                massError = true;
                            }
                    }
                }
            }

            Assert.True(massError);//сообщает, есть ли в коллекции такая ошибка
            Assert.Equal("искусственно вызванная ошибка", ((badRequestResult.Value as SerializableError).Values.First() as string[])[0]); //проверка на содержание
        }

    }
}
