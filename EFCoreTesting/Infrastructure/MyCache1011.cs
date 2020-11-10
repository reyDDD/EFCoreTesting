using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure
{
    public class MyCache1011
    {
        public MemoryCache MemoryCache { get; set; }
        public CancellationTokenSource token { get; set; }
        public MyCache1011()
        {
            MemoryCache = new MemoryCache(new MemoryCacheOptions { SizeLimit = 12 });
            token = new CancellationTokenSource();
        }
    }
}
