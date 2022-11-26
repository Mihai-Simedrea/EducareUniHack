namespace EducareBE.Models.Entities
{
    public class University: BaseEntity
    {
        public string Name { get; set; }
        public int TotalSubjects { get; set; }
        public int TotalExercices { get; set; }
        public int TotalFields { get; set; }

        // one to many
        public List<Faculty>? Faculties { get; set; }

    }
}
