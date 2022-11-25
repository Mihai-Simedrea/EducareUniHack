namespace EducareBE.Models.Entities
{
    public class University: BaseEntity
    {
        public string Name { get; set; }

        // one to many
        public User? User { get; set; }

    }
}
