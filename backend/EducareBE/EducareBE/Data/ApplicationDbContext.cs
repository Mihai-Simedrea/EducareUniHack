using EducareBE.Models.Entities;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<User> Users { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
