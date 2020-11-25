using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages.After2111
{
    public class Service2511
    {
        public async void Pusk(int x, int y)
        {
            await MyFuncDelegate.Invoke(x, y);
        }
        public event Func<int, int, Task> MyFuncDelegate;
    }
}
