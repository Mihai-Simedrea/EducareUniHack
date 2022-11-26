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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
                .HasMany(c => c.Faculties)
                .WithOne(e => e.University);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Profile)
                .WithOne(b => b.User)
                .HasForeignKey<Profile>(b => b.UserId);

            modelBuilder.Entity<EnrolledCourses>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.EnrolledCourses)
                .HasForeignKey(sc => sc.CourseId);


            modelBuilder.Entity<EnrolledCourses>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.EnrolledCourses)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Like>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.Likes)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<Like>()
                .HasOne<SubjectAddedBy>(sc => sc.SubjectAddedBy)
                .WithMany(s => s.Likes)
                .HasForeignKey(sc => sc.SubjectAddedById);

            PopulateUniversity(modelBuilder);
            PopulateFaculty(modelBuilder);
            PopulateFields(modelBuilder);
            PopulateCourses(modelBuilder);
            PopulateSubects(modelBuilder);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectAddedBy> SubjectsAddedBy { get; set;}
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<EnrolledCourses> EnrolledCourses { get; set; }
        public DbSet<Like> Likes { get; set; }


        private void PopulateUniversity(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<University>()
            .HasData(
                new University
                {
                    Id = 1,
                    Name = "Polytechnic University of Timisoara"
                },
                 new University
                 {
                     Id = 2,
                     Name = "Vest University of Timisoara"
                 }
            );
        }

        private void PopulateFaculty(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
            .HasData(
                new Faculty
                {
                    Id = 1,
                    Name = "Automation And Computers",
                    UniversityId = 1
                },
                new Faculty
                {
                    Id = 2,
                    Name = "Electronics and Telecomunication",
                    UniversityId = 2
                },
                new Faculty
                {
                    Id = 3,
                    Name = "Faculty of Finance and Banking",
                    UniversityId = 2
                }
            );
        }


        private void PopulateFields(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>()
            .HasData(
                new Field
                {
                    Id = 1,
                    Name = "Informatics",
                    FacultyId = 1
                },
                new Field
                {
                    Id = 2,
                    Name = "Computers and Information Technology",
                    FacultyId = 1
                },
                new Field
                {
                    Id = 3,
                    Name = "Informatics",
                    FacultyId = 2
                }
            );
        }

        private void PopulateCourses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
            .HasData(
                new Course
                {
                    Id = 1,
                    Name = "POO",
                    Year = 2,
                    FieldId = 2
                },
                new Course
                {
                    Id = 2,
                    Name = "SDA",
                    Year = 2,
                    FieldId = 2
                },
                new Course
                {
                    Id = 3,
                    Name = "TD",
                    Year = 4,
                    FieldId = 2
                }
            );
        }

        private void PopulateSubjects(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Subject>()
            .HasData(
                new Subject
                {
                    Id = 1,
                    Name = "Objects and Classes",
                    CourseId = 1
                },
                new Subject
                {
                    Id = 2,
                    Name = "Polymorphism",
                    FieldId = 1
                },
                new Subject
                {
                    Id = 3,
                    Name = "Errors",
                    Year = 4,
                    FieldId = 1
                }
            );
        }
    }
}
