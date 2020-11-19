using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Thi
{
    public class ThisBase
    {
        public string Template { get; set; }

        public ThisBase SetStringFrombase(string text)
        {
            Template = text;
            return this;
        }

        public ThisBase SetNullFrombase(string text = null)
        {
            if (text == null)
            {
                return null;
            }
            Template = text;
            return this;
        }

        public ThisBase GetStringFromBase()
        {
            return this;
        }
        public ThisBase AddToBase(string text)
        {
            Template += text;
            return this;
        }
    }
}
