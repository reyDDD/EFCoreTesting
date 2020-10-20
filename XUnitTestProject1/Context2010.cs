using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public class Context2010
    {
        protected DbContextOptions<Context> ContextOptions { get; }
        public Context2010(DbContextOptions<Context> contextOptions)
        {
            ContextOptions = contextOptions;
        }
    }
}
