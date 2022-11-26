namespace EducareBE.Models.Entities
{
    public class EnrolledCourses: BaseEntity
    {

        public int CourseId { get; set; }
        public int UserId { get; set; }
        public Course Course { get; set; }
        public User User { get; set; }
        public bool? IsFavoirte { get; set; } = false;
        public bool? IsEnrolled { get; set; } = false;
    }
}
