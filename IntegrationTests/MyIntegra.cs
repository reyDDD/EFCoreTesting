using EFCoreTesting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class MyIntegra : Iintegra
    {
        public List<string> ReturnList()
        {
            return new List<string> { "nevelikapoterya", "velikapoterya", "nepoterya", "wasfinded" };
        }
    }
}
