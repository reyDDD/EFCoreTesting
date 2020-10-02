﻿using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<EFCoreTesting.Startup>>
    {
        private readonly WebApplicationFactory<EFCoreTesting.Startup> _factory;

        public BasicTests(WebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/OneMany/Work2109/")]
        [InlineData("/")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
