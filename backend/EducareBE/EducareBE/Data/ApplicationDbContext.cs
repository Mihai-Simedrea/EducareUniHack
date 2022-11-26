using EducareBE.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace EducareBE.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=educare-server.database.windows.net;Database=AppDb;User Id=unihack-hackathon;password=test123AA!;Trusted_Connection=False;MultipleActiveResultSets=true");
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
                .HasMany(c => c.Faculties)
                .WithOne(e => e.University);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Profile)
                .WithOne(b => b.User)
                .HasForeignKey<Profile>(b => b.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
