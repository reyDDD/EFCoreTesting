using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod()
        {
            //Организация
            var mockRepository = new Mock<ICartRepository>();
            mockRepository.Setup(m => m.ReturnCart()).Returns(
                new List<Cart>
                {
                    new Cart{Id=1, Articul = "SA1222", Name = "Чашка с принтом", Count = 1},
                    new Cart{Id=2, Articul = "SA1200", Name = "Футболка с принтом", Count = 2},
                    new Cart{Id=3, Articul = "SA1400", Name = "Переходник", Count = 1}
                });
            var viewComponent = new EFCoreTesting.Components.Cart(mockRepository.Object);

            //Действие
            ViewViewComponentResult result = viewComponent.Invoke() as ViewViewComponentResult;

            //Утверждение
            Assert.IsType<List<Cart>>(result.ViewData.Model); //проверка типа модели
            Assert.Equal("SA1200", ((List<Cart>)result.ViewData.Model)[1].Articul); // проверка равенства значения
        }
    }
}
