using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class Notifiyer
    {
        public async Task PuskNotify(int x, string y)
        {
            if (WorkNotify != null)
            {
                await WorkNotify.Invoke(x, y);
            }
        }

        public event Func<int, string, Task> WorkNotify;
    }
}
