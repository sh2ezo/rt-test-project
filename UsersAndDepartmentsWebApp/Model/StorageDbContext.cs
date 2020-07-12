using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAndDepartmentsWebApp.Model
{
    public class StorageDbContext : DbContext
    {
        /// <summary>
        /// Creates an instance of the <see cref="StorageDbContext"/>.
        /// </summary>
        /// <param name="options"></param>
        public StorageDbContext(DbContextOptions<StorageDbContext> options) :
            base(options)
        {
        }

        /// <summary>
        /// Gets the set of users.
        /// </summary>
        public DbSet<User> Users { get; }

        /// <summary>
        /// Gets the set of departments.
        /// </summary>
        public DbSet<Department> Departments { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
                e.Property(u => u.Id)
                    .HasColumnName("Id");

                e.Property(u => u.DepartmentId)
                    .HasColumnName("DepId");

                e.Property(u => u.FullName)
                    .HasColumnName("FullName");
            });

            modelBuilder.Entity<Department>(e =>
            {
                e.HasKey(d => d.Id);
                e.Property(d => d.Id)
                    .HasColumnName("Id");

                e.Property(d => d.Title)
                    .HasColumnName("Title");

                e.HasMany(d => d.Users)
                    .WithOne()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
