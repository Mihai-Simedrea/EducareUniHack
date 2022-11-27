namespace EducareBE.Models.Entities
{
    public class BlobContent : BaseEntity
    {
        public int SubjectAddedById { get; set; }
        public SubjectAddedBy SubjectAddedBy { get; set; }
        public int ExerciseId { get; set; }

        public Exercise Exercise { get; set; }
        public string Content { get; set; }
    }
}
