using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class InjectService
    {
        private List<string> List { get; set; } = new List<string> { "Andrew", "Hanna", "Armand" };
        public IEnumerable<string> ReturnListFriends()
        {
            return List;
        }
        public IEnumerable<string> AddFriends(params string[] names)
        {
            List.AddRange(names);
            return List;
        }

    }
}
