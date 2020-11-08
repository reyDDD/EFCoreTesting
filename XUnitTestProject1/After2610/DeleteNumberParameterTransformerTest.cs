using EFCoreTesting.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class DeleteNumberParameterTransformerTest
    {

        [Fact]
        public void Replace()
        {
            DeleteNumberParameterTransformer transformer = new DeleteNumberParameterTransformer();

            var output = transformer.TransformOutbound("Work1209ss");
            Assert.Equal("Workss", output);
        }
    }
}
