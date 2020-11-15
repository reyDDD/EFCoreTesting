﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Models
{
    public class IdentyyDbContext : IdentityDbContext
    {
        public IdentyyDbContext(DbContextOptions<IdentyyDbContext> options)
            : base(options)
        {
        }
    }
}
