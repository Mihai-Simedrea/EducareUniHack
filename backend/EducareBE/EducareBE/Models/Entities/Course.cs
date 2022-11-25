namespace EducareBE.Models.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set;  }

        // one to one

        // one to many
        public ICollection<Field?> Fields { get; set; }
    }
}
