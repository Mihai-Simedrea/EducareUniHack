using AutoMapper;
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
        }
      
    }
}
