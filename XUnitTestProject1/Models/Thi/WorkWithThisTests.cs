using EFCoreTesting.Models.Thi;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.Models.Thi
{
    public class WorkWithThisTests
    {
        [Fact]
        public void ReturnConcatline()
        {
            WorkWithThis work = new WorkWithThis();
           string res =  work.Work();

            Assert.Equal("от родителя для родителя от ребенка для родителя", res);
        }

        [Fact]
        public void ReturnNull()
        {
            WorkWithThis work = new WorkWithThis();
            string res = work.Work2();

            Assert.Null(res);
        }

        [Fact]
        public void ReturnNameOf()
        {
            WorkWithThis work = new WorkWithThis();
            string res = work.NameOfWork("конхфетка");

            Assert.Equal($"Переменная с именем paramName содержит значение: конхфетка", res);
        }
    }
}
