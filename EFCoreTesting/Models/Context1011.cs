using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Context1011 : DbContext
    {
        public Context1011(DbContextOptions<Context1011> options): base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
