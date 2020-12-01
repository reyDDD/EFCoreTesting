using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Chain0112
{
    public class Original
    {
        public string MyProperty { get; private set; }


        public Original SetValuePrivateProperty(string x)
        {
            MyProperty = "установка знаения из закрытого метода";
            return this;
        }
    }
}
