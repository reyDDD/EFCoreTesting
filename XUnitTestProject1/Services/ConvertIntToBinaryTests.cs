using EFCoreTesting.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.Services
{
    public class ConvertIntToBinaryTests
    {

        [Fact]
        public void TestConvertToByte()
        {
            string m = Console.ReadLine();
            int n = int.Parse(m);

            ConvertIntToBinary convertInt = new ConvertIntToBinary();
            BitArray mas = convertInt.Convert(13);
            int res = convertInt.SummOne(mas);
            Assert.True(res == 2);
        }
       

    }
}
