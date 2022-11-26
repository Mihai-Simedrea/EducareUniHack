namespace EducareBE.Models.Entities
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        
        // one to one

        // one to many
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
