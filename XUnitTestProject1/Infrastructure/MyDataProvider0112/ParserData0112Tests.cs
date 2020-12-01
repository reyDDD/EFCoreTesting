using EFCoreTesting.Infrastructure.MyDataProvider0112;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Infrastructure.MyDataProvider0112
{
    public class ParserData0112Tests
    {
        [Fact]
        public void TestSubstring()
        {
            ParserData0112 parser = new ParserData0112();
            var res = parser.Sub("ones:dsdsd");
            Assert.Equal("ones", res.key);
        }
        [Fact]
        public void TestSubstringVal()
        {
            ParserData0112 parser = new ParserData0112();
            var res = parser.Sub("ones:dsdsd");
            Assert.Equal("dsdsd", res.value);
        }
    }
}
