using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class NewContext : DbContext
    {
        public NewContext(DbContextOptions<NewContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;", opt => opt.EnableRetryOnFailure());

            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<AutoSuplier> AutoSupliers { get; set; }
        public DbSet<NotNullModel> NotNullModels { get; set; }
        public DbSet<House> Houses { get; set; }

    }
}
