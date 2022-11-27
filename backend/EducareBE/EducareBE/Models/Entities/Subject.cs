namespace EducareBE.Models.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }

        // one to many
        public int? CourseId { get; set; }
        public Course? Course{ get; set; }

        public List<SubjectAddedBy>? SubjectsAddedBy { get; set; }
        // public List<Exercise>? Exercises { get; set; }
    }
}
