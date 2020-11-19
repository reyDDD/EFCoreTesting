using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Thi
{
    public class WorkWithThis
    {
        public string Work()
        {
            ThisBase bases = new ThisBase();
            var res = bases.GetStringFromBase().SetStringFrombase("от родителя для родителя ").AddFromChild("от ребенка для родителя").Template;
            return res;
        }
    }
}
