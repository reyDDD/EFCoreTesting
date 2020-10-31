using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public interface IService3110
    {
        string ReturnName();
    }
    public class Service3110 : IService3110
    {
        public string ReturnName()
        {
            return "Alsu";
        }
    }
}
