using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Context;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
    }
}