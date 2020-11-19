using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Thi
{
    public static class AddToThis
    {
        public static ThisBase AddFromChild(this ThisBase @this, string text)
        {
            @this.AddToBase(text);
            return @this;
        }
    }
}
