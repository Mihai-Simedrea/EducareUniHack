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
                .HasForeignKey(sc => sc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne<SubjectAddedBy>(sc => sc.SubjectAddedBy)
                .WithMany(s => s.Likes)
                .HasForeignKey(sc => sc.SubjectAddedById);

            PopulateUniversity(modelBuilder);
            PopulateFaculty(modelBuilder);
            PopulateFields(modelBuilder);
            PopulateCourses(modelBuilder);
            PopulateSubjects (modelBuilder);
            PopulateSubjectsAddedBy(modelBuilder);

            PopulateUsers(modelBuilder);
            PopulateEnroledCourses(modelBuilder);
            PopulateLikes(modelBuilder);

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
        public DbSet<BlobContent> BlobContents { get; set; }
        // public DbSet<Exercise> Exercises { get; set; }  
        // 

        public DbSet<Exercise> Exercises { get; set; }

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
                     },
                     
                new University
                {
                    Id = 10,
                    Name = "Massachusetts Institute of Technology"
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
                    Name = "Faculty of Mechanical Engineering",
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
               UserList
            );
        }

        private void PopulateSubjectsAddedBy(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectAddedBy>()
            .HasData(
                new SubjectAddedBy
                {
                    Id = 1,
                    Name = "Definition",
                    SubjectId = 1,
                    UserId = 1,
                },
                new SubjectAddedBy
                {
                    Id = 2,
                    Name = "Lab Example",
                    SubjectId = 1,
                    UserId = 2,
                },
                new SubjectAddedBy
                {
                    Id = 3,
                    Name = "Coruse Example",
                    SubjectId = 1,
                    UserId = 3,
                },
                new SubjectAddedBy
                {
                    Id = 6,
                    Name = "Definition",
                    SubjectId = 2,
                    UserId = 2,
                },
                new SubjectAddedBy
                {
                    Id = 7,
                    Name = "Lab Example",
                    SubjectId = 2,
                    UserId = 1,
                },
                new SubjectAddedBy
                {
                    Id = 8,
                    Name = "Coruse Example",
                    SubjectId = 2,
                    UserId = 3,
                }
            );
        }

        private void PopulateEnroledCourses(ModelBuilder modelBuilder) {
            modelBuilder.Entity<EnrolledCourses>()
           .HasData(
                new EnrolledCourses
                {
                    Id = 1,
                    CourseId = 1,
                    UserId = 1,
                    IsEnrolled = true,
                },
                new EnrolledCourses
                {
                    Id = 2,
                    CourseId = 2,
                    UserId = 1,
                    IsEnrolled = true,
                },
                new EnrolledCourses
                {
                    Id = 3,
                    CourseId = 2,
                    UserId = 1,
                    IsFavoirte = false
                }
            );
            return;  
        }
        private void PopulateLikes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
            .HasData( 
                new Like
                {
                    Id = 1,
                    UserId= 1,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 2,
                    UserId = 2,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 3,
                    UserId = 3,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 4,
                    UserId = 4,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 5,
                    UserId = 4,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 6,
                    UserId = 5,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 7,
                    UserId = 6,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 8,
                    UserId = 7,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 9,
                    UserId = 8,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 10,
                    UserId = 10,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 11,
                    UserId = 11,
                    SubjectAddedById = 1,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 12,
                    UserId = 12,
                    SubjectAddedById = 1,
                    DislikesCount = 1
                },
                new Like
                {
                    Id = 13,
                    UserId = 2,
                    SubjectAddedById = 2,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 14,
                    UserId = 3,
                    SubjectAddedById = 2,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 15,
                    UserId = 4,
                    SubjectAddedById = 2,
                    LikesCount = 1,
                },
                new Like
                {
                    Id = 16,
                    UserId = 5,
                    SubjectAddedById = 2,
                    DislikesCount = 0
                },
                new Like
                {
                    Id = 17,
                    UserId = 9,
                    SubjectAddedById = 2,
                    LikesCount = 1,
                }
            );
            return; 
        }


        private List<User> UserList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "jhon.smith@student.upt.ro",
                    Password = "password",
                    UserName = "johnny47"
                },
                new User
                {
                    Id = 2,
                    Email = "makhur.khena@student.upt.ro",
                    Password = "password",
                    UserName = "makhur.khena"
                },
                new User
                {
                    Id = 3,
                    Email = "zaya.del@student.upt.ro",
                    Password = "password",
                    UserName = "zayaTheBest"
                },
                new User
                {
                    Id = 4,
                    Email = "gerdi.ninkhafk@student.upt.ro",
                    Password = "password",
                    UserName = "ninkhafk99"
                },
                new User
                {
                    Id = 5,
                    Email = "rhiannon.bovun@student.upt.ro",
                    Password = "password",
                    UserName = "bovun2003"
                },
                new User
                {
                    Id = 6,
                    Email = "rol.khihrerl@student.upt.ro",
                    Password = "password",
                    UserName = "khihrerl007"
                },
                 new User
                 {
                     Id = 7,
                     Email = "shepard.hanni@student.upt.ro",
                     Password = "password",
                     UserName = "hanni_"
                 },
                new User
                {
                    Id = 8,
                    Email = "buiron.tin@student.mit.us",
                    Password = "password",
                    UserName = "tin77"
                },
                new User
                {
                    Id = 9,
                    Email = "rell.findazrum@student.lca.de",
                    Password = "password",
                    UserName = "rell_findar1"
                },
                new User
                {
                    Id = 10,
                    Email = "xandra.tiang@student.upt.ro",
                    Password = "password",
                    UserName = "alexandra"
                },
                new User
                {
                    Id = 11,
                    Email = "andrew.techel@student.upt.ro",
                    Password = "password",
                    UserName = "andreeew"
                },
                new User
                {
                    Id = 12,
                    Email = "gustavo.del@student.upt.ro",
                    Password = "password",
                    UserName = "gustavo412"
                }
            };
    }
}
