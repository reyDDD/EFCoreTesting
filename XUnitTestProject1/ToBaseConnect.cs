using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace XUnitTestProject1
{
    public class ToBaseConnect : DbContext, IDisposable, IContext
    {
        protected DbConnection Connection { get; }

        public ToBaseConnect(DbContextOptions<ToBaseConnect> options) : base(options)
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;");
   
        }

        public ToBaseConnect()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;");
        }

        public Context Connect()
        {
            return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(Connection).Options);
        }


        //public  void Dispose()
        //{
        //    Connection.Dispose();
        //}
    }
}
