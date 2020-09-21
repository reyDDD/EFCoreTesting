using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages
{
    public partial class Repeat_21_09
    {
        public int MyProperty { get; set; } = 5;

        public IEnumerable<Address> ReturnList()
        {
            return one2Many.GetAddressWithFilter1();
        }

        Dictionary<string, object> list = new Dictionary<string, object> {
        {"on", "rr" },
        {"off", "zz" },
        {"yes", "ahah" }};

        public void Arifmetic()
        {
            MyProperty += 10;
        }
    }
}
