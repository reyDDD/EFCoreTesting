using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class TestWithContext : IClassFixture<NewContext>
    {
        private NewContext context;
        public TestWithContext(NewContext context)
        {
            this.context = context;
        }

        [Fact]
        public void TestWork2809()
        {
            using (var conne = context.CreateContext())
            {
                var strategy = conne.Database.CreateExecutionStrategy();
                strategy.Execute(() =>
                    {
                        using (var transaction = context.Connection.BeginTransaction())
                        {
                            using (var conn = context.CreateContext(transaction))
                            {
                                Work2809 work2809 = new Work2809(conn);
                                var controller = new Work0810Controller(work2809);

                                var action = controller.Index2();

                                var result = Assert.IsType<ViewResult>(action);
                                Assert.IsType<Address>(result.ViewData.Model);
                            }

                            using (var conn = context.CreateContext(transaction))
                            {
                                Work2809 work2809 = new Work2809(conn);
                                var controller = new Work0810Controller(work2809);

                                var action = controller.Invoke();

                                var result = Assert.IsType<ViewViewComponentResult>(action);
                                var model = Assert.IsType<string>(result.ViewData.Model);
                                Assert.Equal("текст для модели", model);
                            }

                            transaction.Commit();
                        }
                    });
            }
        }
    }
}
