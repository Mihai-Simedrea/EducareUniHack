namespace EducareBE.Models.Entities
{
    public class University: BaseEntity
    {
        public string Name { get; set; }

        // one to many
        public List<Faculty>? Faculties { get; set; }

    }
}
