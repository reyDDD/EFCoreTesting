using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure
{
    public class Cache0211
    {
        public MemoryCache Cache { get; set; }
        public Cache0211()
        {
            Cache = new MemoryCache(new MemoryCacheOptions { SizeLimit = 25 });
        }
    }
}
