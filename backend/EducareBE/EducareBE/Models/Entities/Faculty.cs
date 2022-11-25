namespace EducareBE.Models.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }

        // one to one

        // one to many
        public ICollection<University?> Universities { get; set; }
        public Field? Field { get; set; }
    }
}
