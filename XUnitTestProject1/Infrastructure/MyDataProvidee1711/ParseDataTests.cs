using EFCoreTesting.Infrastructure.MyDataProvidee1711;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.Infrastructure.MyDataProvidee1711
{
    public class ParseDataTests
    {

        [Theory]
        [InlineData("тут вообще никого не было")]
        public void SubMethodTesting(string stroca)
        {
            var parser = new ParseData();
            var result = parser.Sub(stroca);
            Assert.Equal("тут", result.key);
            Assert.Equal("был Василий", result.val);
        }

        [Theory]
        [InlineData("тут вообще никого не было")]
        public void SubMethodTesting_reurnException(string stroca)
        {
            var parser = new ParseData();
            Assert.Throws<ArgumentNullException>(() => parser.Sub(stroca));
 
        }
    }
}
