namespace EducareBE.Models.Entities
{
    public class Like : BaseEntity
    {
        public int UserId { get; set; }
        public int SubjectAddedById { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
        public User User { get; set; }
        public SubjectAddedBy SubjectAddedBy { get; set; }
    }
}
