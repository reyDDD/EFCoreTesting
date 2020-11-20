using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTesting.Services
{


    public struct Struct2011 : IDisposable
    {
        public string MyProperty;
        public int no;
        public Struct2011(string paramm, int bb)
        {
            MyProperty = paramm;
            no = bb;
        }
        public string Work(int x)
        {
            return $"This is {x}";
        }

        public void Dispose()
        {
            MyProperty = null;
        }
    }
}
