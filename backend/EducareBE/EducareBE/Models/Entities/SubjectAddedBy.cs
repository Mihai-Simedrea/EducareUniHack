namespace EducareBE.Models.Entities
{
    public class SubjectAddedBy: BaseEntity
    {
        public string Name { get; set; }

        // one to many
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<BlobContent>? Blobs { get; set; }
    }
}
