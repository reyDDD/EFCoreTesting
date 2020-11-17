using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.DIWithParam
{
    public class ClassForDI1711
    {
        public int Age { get; set; }

        public ClassForDI1711(int age)
        {
            Age = age;
        }
    }
}
