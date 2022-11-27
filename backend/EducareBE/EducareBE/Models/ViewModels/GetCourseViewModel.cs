namespace EducareBE.Models.ViewModels
{
    public class GetCourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public int? FieldId { get; set; }
        

        public string UniversityName { get; set; }  
        public string FieldUniversity { get; set; }  
        public string FieldName { get; set;  }

    }
}
