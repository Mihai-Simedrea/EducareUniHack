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
            CreateMap<University, GetUniversityViewModel>().ReverseMap(); 
            CreateMap<Faculty, GetFacultiesViewModel>().ReverseMap();
            CreateMap<Course, AddCourseDto>().ReverseMap();


            CreateMap<University, GetUniversityViewModel>().ReverseMap();
            CreateMap<Field, GetFieldsViewModel>().ReverseMap();
            CreateMap<Course, GetCourseViewModel>()
                .ForMember(dest => dest.FacultyName, opts => opts.MapFrom(src => src.Field.Faculty.Name))
                .ForMember(dest => dest.UniversityName, opts => opts.MapFrom(src => src.Field.Faculty.University.Name));

            CreateMap<Subject, GetAllSubjectsViewModel>();
            CreateMap<SubjectAddedBy, GetAllSubjectsAddedByViewModel>().ReverseMap();
        }
      
    }
}
