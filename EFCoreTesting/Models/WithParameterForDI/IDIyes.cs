using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.WithParameterForDI
{
    public class ForT
    {
        public int MyProperty { get; set; }
    }
    public interface IDIyes
    {
        int MyProperty { get; set; }
    }

    public class DIyes : IDIyes
    {
        public int MyProperty { get; set ; }
        public DIyes(ForT x)
        {
            MyProperty = x.MyProperty;
        }
    }
}
