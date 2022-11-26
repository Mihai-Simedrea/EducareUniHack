namespace EducareBE.Models.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set;  }
        public bool IsFavoirt { get; set; } = false;
        // one to one

        // one to many
        public int FieldId { get; set; }
        public ICollection<Field?> Fields { get; set; }
    }
}
