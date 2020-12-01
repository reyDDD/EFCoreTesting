using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.WithParamForDI
{
    public interface IOru
    {
          int MyProperty { get; set; }
          string MyProperty2 { get; set; }
    }

    public class Oru : IOru
    {
        public int MyProperty { get; set; }
        public string MyProperty2 { get; set; }
        public Oru(int x, string y)
        {
            MyProperty = x;
            MyProperty2 = y;
        }
    }
}
