namespace EducareBE.Models.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        
        // one to one
        public int? UniversityId { get; set; }
        public int? FacultyId { get; set; }     
        public int? FiledId { get; set; } 

        // many to many
        public int? CourseId { get; set; }
    }
}
