using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TypeWrite
{
    public record Test2011
    {
        public string MyProperty { get; set; }
        public string MyProperty2 { get; }
        public Test2011(string one, string two) => (MyProperty, MyProperty2) = (one, two);
        public override string ToString()
        {
            StringBuilder s = new();
            this.PrintMembers(s);
            return s.ToString();
        }
    }


    public record InTest2011 : Test2011
    {
        public string MyProperty3 { get; }
        public InTest2011(string one, string two, string three) : base(one, two) => MyProperty3 = three;
    }

    public sealed record InTest2011Seald : Test2011
    {
        public string MyProperty4 { get; }
        public InTest2011Seald(string one, string two, string three) : base(one, two) => MyProperty4 = three;

 
    }

    //ниже позиционная запись - чето она не работает
    //public record PositionWrite(string Ones, string Twos, string Three) : Test2011(Ones, Twos);

    public class WorkWithRecord
    {
        public string Worker()
        {
            Test2011 test2011 = new Test2011("start", "end");
            var res = test2011.ToString();

            Test2011 test2012 = test2011 with { MyProperty = "Ha, changed!" };
            return test2012.ToString();
        }
    }
}
