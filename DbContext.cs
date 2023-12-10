using GreenThumb;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class YourDbContext : DbContext
{
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Instruction> Instructions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>()
            .HasMany(p => p.FollowingInstructions)
            .WithOne(i => i.Plant)
            .HasForeignKey(i => i.PlantId);
    }
}
