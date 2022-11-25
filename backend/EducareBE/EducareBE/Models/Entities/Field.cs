namespace EducareBE.Models.Entities
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        
        // one to one

        // one to many
        public ICollection<Faculty?> Faculties { get; set; }
        public Course? Course { get; set; }
    }
}
