using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
   public class NotNullServicesTests : IClassFixture<MyWorkContext>
    {
        private MyWorkContext context;
        public NotNullServicesTests(MyWorkContext context)
        {
            this.context = context;
        }

        [Fact]
        public void AddHouseToStreetTest()
        {
            NotNullModel notNullModel = new NotNullModel()
            {
                Street = "Чайковского",
                House = new List<House> { new House { Home = "самый большой" } }
            };

            NotNullModelService service = new NotNullModelService(context.CreateContext());

            //дествие
            var result = service.AddHouseToStreet(notNullModel, true);


            //утверждение
            Assert.True(result.House.Count() > 0);
        }


        [Fact]
        public void NotNullControllerTestsTest()
        {
            NotNullModel notNullModel = new NotNullModel()
            {
                Street = "Чайковского",
                House = new List<House> { new House { Home = "самый большой" } }
            };
            NotNullModelService service = new NotNullModelService(context.CreateContext());
            NotNullController controller = new NotNullController(service);

            //дествие
            var result = controller.Index(notNullModel, true) as RedirectToActionResult;
             

            //утверждение
            Assert.True(result.ActionName == "Index2");
        }

        [Fact]
        public void NotNullController_Index2_Test()
        {
            NotNullModel notNullModel = new NotNullModel()
            {
                Street = "Чайковского",
                House = new List<House> { new House { Home = "самый большой" } }
            };
            NotNullModelService service = new NotNullModelService(context.CreateContext());
            NotNullController controller = new NotNullController(service);

            //дествие
            var result = (controller.Index2(notNullModel) as ViewResult).ViewData.Model as NotNullModel;


            //утверждение
            Assert.True(result.House.Count() > 0);
        }


        [Fact]
        public void NotNullController_InvokeMethod_Test()
        {
            //чтобы отпработала проверка вызова метода класс контроллера в конструкторе должен принимать интерфейс, а не класс
            //в качестве экземляра для передачи в параметр можно как создать объект воручную, так и с помощью It.IsAny<NotNullModel>()
            //если в Verifiable передать аргумент, он появиться в комментариях об ошибке в результатах теста

 
            var mockService = new Mock<INotNullModelService>();
            mockService.Setup(repo => repo.ReturnNotNullModelWithHose(It.IsAny<NotNullModel>())).Returns(It.IsAny<NotNullModel>()).Verifiable("в процессе отработки метод ReturnNotNullModelWithHose не был вызван, а должен был бы!!!"); // метод 

            NotNullController controller = new NotNullController(mockService.Object);

            var para = new NotNullModel { Id = 7, Street = "вотблядская улица" };

            //действие
            var result = controller.Index2(para);


            //утверждение
            Assert.IsNotType<BadRequestResult>(result);
            Assert.IsType<ViewResult>(result);


            mockService.Verify(); //метод позволяет проверить, что все установленные методы в mockService были вызваны в процессе отправботки метода
        }

    }
}
