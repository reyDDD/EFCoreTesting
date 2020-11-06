using EFCoreTesting.Areas.Two.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class HomeTwoControllerTest
    {
        
        [Fact]
        public void HomeTwo_Index2_returnUser()
        {
            //подготовка
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            HomeTwoController controller = new HomeTwoController(configuration);

            //реализация
            var actionResult = controller.Index2();


            //проверка
            var result = Assert.IsType<ViewResult>(actionResult);
            var data = Assert.IsType<string>(result.ViewData.Model);
            Assert.Equal("Uzvar", data);
        }
    }
}
