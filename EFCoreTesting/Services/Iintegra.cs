using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public interface Iintegra
    {
        List<string> ReturnList();
    }
    public class Integra : Iintegra
    {
        public List<string> ReturnList()
        {
            return new List<string> { "yolka", "bulka", "nafig" };
        }
    }
}
