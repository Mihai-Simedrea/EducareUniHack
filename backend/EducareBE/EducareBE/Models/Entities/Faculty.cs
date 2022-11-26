namespace EducareBE.Models.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }

        // one to one

        // one to many
        public int UniversityId { get; set; }
        public University University { get; set; }
        // public Field? Field { get; set; }

        public List<Field> Fields { get; set; }
    }
}
