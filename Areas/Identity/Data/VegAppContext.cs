
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VegApp.Areas.Identity.Data;
using System.Collections.Generic;
using VegApp.Entities;

namespace VegApp.Data;

public class VegAppContext : IdentityDbContext<VegAppUser, UserRole, Guid>
{
    public VegAppContext(DbContextOptions<VegAppContext> options)
        : base(options)
    {
    }


    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<VegAppUser>().HasMany(u => u.Products).WithOne(c => c.VegAppUser);

    }
}

