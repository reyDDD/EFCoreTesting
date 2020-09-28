using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace XUnitTestProject1
{
    public class MyWorkContext : IDisposable
    {
        public DbConnection Connection { get; }

        public MyWorkContext()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;");
        }


        public Context CreateContext()
        {
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(Connection).Options);
        }


        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
