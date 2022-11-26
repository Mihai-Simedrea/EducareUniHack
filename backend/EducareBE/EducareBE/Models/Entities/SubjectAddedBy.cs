namespace EducareBE.Models.Entities
{
    public class SubjectAddedBy: BaseEntity
    {
        public string Name { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        // one to many
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
    }
}
