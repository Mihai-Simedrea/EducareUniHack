namespace EducareBE.Models.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set;  }
        public bool IsFavorite { get; set; }
        // one to one

        // one to many
        public int? FieldId { get; set; }
        public Field? Field { get; set; }
    }
}
