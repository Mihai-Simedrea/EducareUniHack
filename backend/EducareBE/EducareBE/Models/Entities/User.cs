namespace EducareBE.Models.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Profile Profile { get; set; }

        // one to one
        //public int? UniversityId { get; set; }
        //public int? FacultyId { get; set; }     
        // public int? FiledId { get; set; } 

        // one to many
        public List<SubjectAddedBy>? SubjectsAddedBy { get; set; }
        // public List<Exercise>? Exercises { get; set; }

        // many to many
        public ICollection<EnrolledCourses>? EnrolledCourses { get; set; }
        public ICollection<Like>? Likes { get; set; }

    }
}
