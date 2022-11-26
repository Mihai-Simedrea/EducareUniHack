using EducareBE.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
            PopulateSubjects (modelBuilder);

            //PopulateUsers(modelBuilder);
           // PopulateEnroledCourses(modelBuilder);
           // PopulateFavoriteCourses(modelBuilder);
            //PopulateLikes(modelBuilder);

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
                },          
                new University
                {
                    Id = 3,
                    Name = "Standford University"
                },
                new University
                {
                    Id = 4,
                    Name = "Massachusetts Institute of Technology"
                },
                 new University
                 {
                Id = 5,
                    Name = "Polytechnic University of Bucharest"
                 },
                  new University
                  {
                Id = 6,
                    Name = "Polytechnic University of Iasi"
                  },
                   new University
                   {
                Id = 7,
                    Name = "Carol Davila University of Medicine"
                   },
                    new University
                    {
                Id = 8,
                    Name = "University of Medicine and Pharmacy of Craiova"
                    },
                     new University
                     {
                Id = 9,
                    Name = "Lucian Blaga University of Sibiu"
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
                    UniversityId = 1
                },
                new Faculty
                {
                    Id = 3,
                    Name = "Faculty Of Managemen And Transportation ",
                    UniversityId = 1
                },
                new Faculty
                {
                    Id = 4,
                    Name = "Faculty of Mechanical Engineerin",
                    UniversityId = 1
                },
                new Faculty
                {
                    Id = 5,
                    Name = "Faculty of Finance and Banking",
                    UniversityId = 1
                },
                 new Faculty
                 {
                     Id = 6,
                     Name = "Automation And Computers",
                     UniversityId = 5
                 },
                new Faculty
                {
                    Id = 7,
                    Name = "Electronics and Telecomunication",
                    UniversityId = 5
                },
                new Faculty
                {
                    Id = 8,
                    Name = "Faculty Of Managemen And Transportation ",
                    UniversityId = 5
                },
                new Faculty
                {
                    Id = 9,
                    Name = "Faculty of Mechanical Engineerin",
                    UniversityId = 5
                },
                new Faculty
                {
                    Id = 10,
                    Name = "Faculty of Finance and Banking",
                    UniversityId = 5
                },
                 new Faculty
                 {
                     Id = 11,
                     Name = "Automation And Computers",
                     UniversityId = 6
                 },
                new Faculty
                {
                    Id = 12,
                    Name = "Electronics and Telecomunication",
                    UniversityId = 6
                },
                new Faculty
                {
                    Id = 13,
                    Name = "Faculty Of Management And Transportation ",
                    UniversityId = 6
                },
                new Faculty
                {
                    Id = 14,
                    Name = "Faculty of Mechanical Engineerin",
                    UniversityId = 6
                },
                new Faculty
                {
                    Id = 15,
                    Name = "Faculty of Finance and Banking",
                    UniversityId = 6
                },
                 new Faculty
                 {
                     Id = 16,
                     Name = "Faculty Of Mathemathics",
                     UniversityId = 2
                 },
                new Faculty
                {
                    Id = 17,
                    Name = "Faculty of Biology",
                    UniversityId = 2
                },
                new Faculty
                {
                    Id = 18,
                    Name = "Faculty Of Managemen And Transportation ",
                    UniversityId = 2
                },
                new Faculty
                {
                    Id = 19,
                    Name = "Faculty of Mechanical Engineerin",
                    UniversityId = 2
                },
                new Faculty
                {
                    Id = 20,
                    Name = "Faculty of Finance and Banking",
                    UniversityId = 2
                },
                 new Faculty
                 {
                     Id = 21,
                     Name = "Faculty of General Medicine",
                     UniversityId = 7
                 },
                new Faculty
                {
                    Id = 22,
                    Name = "Faculty of Dental Medicine",
                    UniversityId = 7
                },
                new Faculty
                {
                    Id = 23,
                    Name = "Faculty of Chirurgy",
                    UniversityId = 7
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
                    Name = "System Engineering",
                    FacultyId = 1
                },
                 new Field
                 {
                     Id = 4,
                     Name = "Telecomunications",
                     FacultyId = 2
                 },
                new Field
                {
                    Id = 5,
                    Name = "Transporting Engineering",
                    FacultyId = 3
                },
                new Field
                {
                    Id = 6,
                    Name = "Management Engineering",
                    FacultyId = 4
                },
                 new Field
                 {
                     Id = 7,
                     Name = "Finance",
                     FacultyId = 5
                 },
                new Field
                {
                    Id = 8,
                    Name = "Bussiness",
                    FacultyId = 5
                },
                new Field
                {
                    Id = 9,
                    Name = "Banking",
                    FacultyId = 5
                },
                 new Field
                 {
                     Id = 10,
                     Name = "Informatics",
                     FacultyId = 1
                 },
                new Field
                {
                    Id = 11,
                    Name = "Computers and Information Technology",
                    FacultyId = 1
                },
                new Field
                {
                    Id = 12,
                    Name = "Informatics",
                    FacultyId = 2
                },
                new Field
                {
                    Id = 13,
                    Name = "General Medicine",
                    FacultyId = 21
                },
                new Field
                {
                    Id = 14,
                    Name = "Dental Medicine",
                    FacultyId = 22
                },
                new Field
                {
                    Id = 15,
                    Name = "Chirurgy",
                    FacultyId = 23
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
                    Name = "PTDM",
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
                    CourseId = 1
                },
                new Subject
                {
                    Id = 3,
                    Name = "Errors",
                    CourseId = 1
                },
                 new Subject
                 {
                     Id = 4,
                     Name = "Sorting Algorims",
                     CourseId = 2
                 },
                new Subject
                {
                    Id = 5,
                    Name = "Advanced sorting algoritms",
                    CourseId = 2
                },
                new Subject
                {
                    Id = 6,
                    Name = "The Oscilloscope",
                    CourseId = 3
                }
            );
        }

        private void PopulateUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Email = "florin.mischie@student.upt.ro",
                    Password = "password",
                    UserName = "Aleksandru"
                },
                new User
                {
                    Id = 2,
                    Email = "test@student.upt.ro",
                    Password = "password",
                    UserName = "Aleksandru"
                },
                new User
                {
                    Id = 3,
                    Email = "test2@student.upt.ro",
                    Password = "password",
                    UserName = "Aleksandru"
                }
            );

        }

        private void PopulateEnroledCourses(ModelBuilder modelBuilder) { return;  }
        private void PopulateFavoriteCourses(ModelBuilder modelBuilder) { return; }
        private void PopulateLikes(ModelBuilder modelBuilder) { return; }
    }
}
