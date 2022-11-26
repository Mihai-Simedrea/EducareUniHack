namespace EducareBE.Models.Entities
{
    public class Profile : BaseEntity
    {
        public string UniversityName { get; set; }
        public string FieldName { get; set; }
        public string FacultyName { get; set; }
        public int StudyYear { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfPosts { get; set; }
        
        // one to one
        public string UserEmail { get; set; }
        public User User { get; set; }
    }
}
