using auth_api.Infra.Entity;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Config;

public class PostgresContext(DbContextOptions<PostgresContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .ToTable("users")
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}