using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Context2510 : DbContext
    {
        public Context2510(DbContextOptions<Context2510> options) : base(options)
        {
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
