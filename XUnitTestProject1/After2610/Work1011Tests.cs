using EFCoreTesting.Areas.Distribute.Controllers;
using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;



namespace XUnitTestProject1.After2610
{
    public class Work1011Tests
    {

        [Fact]
        public void TestWithMock()
        {
            var mock = new Mock<IModel1011>();
            mock.Setup(x => x.AddAddressWithUser(It.IsAny<User>())).Verifiable();

            var controller = new Work1011Controller(mock.Object);
            controller.Index();

            mock.Verify();
        }
    }
}
