namespace EducareBE.Models.Entities
{
    public class BlobContent : BaseEntity
    {
        public SubjectAddedBy SubjectAddedBy { get; set; }
        public string Content { get; set; }
    }
}
