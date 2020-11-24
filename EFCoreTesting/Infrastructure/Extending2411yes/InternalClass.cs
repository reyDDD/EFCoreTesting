using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Extending2411yes
{
    public class InternalClass
    {
        private string MyProperty { get; set; }
        public string ReturnProperty()
        {
            return $"{MyProperty} dobavka";
        }
        public void SetProperty(string prop)
        {
            MyProperty = prop;
        }
    }
}
