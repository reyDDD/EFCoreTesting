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
        public void Test_Index2_NullTerpila()
        {
            using (var res = new ToBaseConnect().Connect())
            {
                Work2809 work2809 = new Work2809(res);

                var resalt = work2809.GetUserWithoutAddress();

                string? dr = resalt.Address?.City;

                Assert.Null(dr);

                CreateConstr.Create();
            }

        }

        [Fact]
        public void Test_Index2()
        {
            using (var res = new ToBaseConnect().Connect())
            {
                Work2809 work2809 = new Work2809(res);
                var controller = new Work0810Controller(work2809);

                var result = controller.Index2();

                Assert.IsType<ViewResult>(result);
                var model = Assert.IsType<Address>(((ViewResult)result).ViewData.Model);
                Assert.Equal("Киев", model.City);
            }

        }
    }

    public class TestNull
    {
        public string MyProperty { get; set; }
        public string MyProperty3 { get; set; }
        public string MyProperty2 { get; set; } = null!;

        public TestNull(string znach, string znach2)
        {
            (MyProperty, MyProperty3) = (znach, znach2);
        }
    }

    public class CreateConstr
    {
        private static Dictionary<int, string> surveyResponses = null!;
        private static Dictionary<int, string>? surveyResponses2 = null;

        public static void Create()
        {
            string? znach = null;

            TestNull testNull = new TestNull(znach, "ds"); //при включении функционала ссылочные типы допускающие нулл, будут типами, не допускающими нулл и попытка передать в параметр string? приводит к предупреждению от компилятора


            int n = -1;
            string? res = (n == -1) ? default : (n == 0) ? "No" : "Yes"; //опять предупреждение, стринг по умолчанию не допускает нулл после изменения настроек

            string dd = surveyResponses[0]; //вылетает ошибка, потому как отрабатывающий метод при возврате значения не проверяет его на предмет существования
            string dd2 = surveyResponses2[0]; // здесь коллекция допускает значение нулл и компилятор предупреждает, что может вылететь ошибка
        }
        //https://docs.microsoft.com/ru-ru/dotnet/csharp/tutorials/nullable-reference-types
    }
}
