using Microsoft.EntityFrameworkCore;
using TeknorixTest.Entities;

namespace TeknorixTest.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(j => j.Id);

                entity.Property(j => j.Code)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(j => j.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(j => j.Description)
                      .IsRequired()
                      .HasMaxLength(1000);

                entity.Property(j => j.PostedDate)
                      .IsRequired();

                entity.Property(j => j.ClosingDate)
                      .IsRequired();

                entity.HasOne<Location>()
                      .WithMany()
                      .HasForeignKey(j => j.LocationId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Department>()
                      .WithMany()
                      .HasForeignKey(j => j.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(j => j.Code)
                      .IsUnique();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(d => d.Title)
                      .IsUnique();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(l => l.City)
                      .HasMaxLength(100);

                entity.Property(l => l.State)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(l => l.Country)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(l => l.Zip)
                      .HasMaxLength(20);
            });
        }
    }
}
