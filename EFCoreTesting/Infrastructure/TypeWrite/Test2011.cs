using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using global::System.ComponentModel;
#if NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2 || NETCOREAPP3_0 || NETCOREAPP3_1 || NET45 || NET451 || NET452 || NET6 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48

using System.ComponentModel;

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Reserved to be used by the compiler for tracking metadata.
    /// This class should not be used by developers in source code.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit
    {
    }
}

#endif

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
        public string MyProperty4 { get; init; }
        public InTest2011Seald(string one, string two, string three) : base(one, two) => MyProperty4 = three;

 
    }

    //ниже позиционная запись
    public record PositionWrite(string Ones, string Twos, string Three) : Test2011(Ones, Twos);

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
