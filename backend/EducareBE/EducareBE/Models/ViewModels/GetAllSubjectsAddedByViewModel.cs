namespace EducareBE.Models.ViewModels
{
    public class GetAllSubjectsAddedByViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? UserId { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string? AddedByName { get; set; }
    }
}
