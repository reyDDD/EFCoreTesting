using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class Work0810ControllerTests  
    {
         
 

        [Fact]
        public void Test_Index2()
        {
            using (var res = new ToBaseConnect().Connect())
            {
                Work2809 work2809 = new Work2809(res);
                var controller = new Work0810Controller(work2809);

                var result = controller.Index2();

                Assert.IsType<ViewResult>(result);
                var model = Assert.IsType<Address>((result as ViewResult).ViewData.Model);
                Assert.Equal("Киев", model.City);
            }

        }
    }
}
