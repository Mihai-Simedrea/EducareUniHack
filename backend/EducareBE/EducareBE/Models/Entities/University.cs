namespace EducareBE.Models.Entities
{
    public class University: BaseEntity
    {
        public string Name { get; set; }

        // one to one
        public User? User { get; set; }

        // one to many
        public Faculty? Faculty { get; set; }

    }
}
