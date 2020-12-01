using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Chain0112
{
    public static class Extend
    {
        public static string Zamostit(this Original original, string tuda)
        {
            original.SetValuePrivateProperty(tuda);
            return original.MyProperty;
        }

        public static string Zamostit2(this Original original, string tuda)
        {
             
            return "что попало левое";
        }

        //public static string ZamostitPryamo(this Original original, string tuda)
        //{
        //    original.MyProperty = "а нельзя установить напрямую, как и планировалось";
        //    return original.MyProperty;
        //}
    }
}
