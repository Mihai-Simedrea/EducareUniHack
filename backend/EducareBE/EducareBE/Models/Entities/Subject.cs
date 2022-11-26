namespace EducareBE.Models.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }

        // one to many
        public int? FieldId { get; set; }
        public Field? Field { get; set; }

        public List<SubjectAddedBy>? SubjectsAddedBy { get; set; }
    }
}
