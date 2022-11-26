namespace EducareBE.Models.Entities
{
    public class Profile : BaseEntity
    {
        public string UniversityName { get; set; }
        public string FieldName { get; set; }
        public string DegreeName { get; set; }
        public int StudyYear { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfPosts { get; set; }
        
        // one to one
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
