using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Extending2411yes
{
    public class Extending2411
    {
        public string Workk(string property)
        {
            WorkClass workClass = new WorkClass();
            workClass.Internal.Raschiril(property);
            return workClass.Internal.ReturnProperty();
        }
    }

    public static class Extend
    {
        public static InternalClass Raschiril(this InternalClass internalClass, string prop)
        {
            internalClass.SetProperty(prop);
            return internalClass;
        }
    }
}
