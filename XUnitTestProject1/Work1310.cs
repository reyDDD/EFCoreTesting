using EFCoreTesting.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class Work1310 : IClassFixture<IServiceProvider>
    {
        private IServiceProvider serviceProvider;

        public Work1310(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [Fact]
        public void TestAddressContainsElemets()
        {
            var mock = new Mock<IServiceProvider>();

            var controller = new Work1310Controller(mock.Object);
            var action = controller.Index();

            Assert.IsNotType<BadRequestObjectResult>(action);

            //мораль сей басни такова - для тестов используй нормальное создание экземляра DB через DI
        }
    }
}
