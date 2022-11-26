using AutoMapper;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using EducareBE.Models.ViewModels;

namespace EducareBE.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, AddCourseDto>().ReverseMap();


            CreateMap<University, GetUniversityViewModel>().ReverseMap();
            CreateMap<Field, GetFieldViewModel>().ReverseMap();
            CreateMap<Course, GetCourseViewModel>().ReverseMap();
        }
      
    }
}
