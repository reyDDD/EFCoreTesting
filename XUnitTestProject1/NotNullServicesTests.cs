using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
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

    }
}
