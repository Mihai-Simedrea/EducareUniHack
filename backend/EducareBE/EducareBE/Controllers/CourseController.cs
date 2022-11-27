using AutoMapper;
using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using EducareBE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {    
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCourses(int id)
        {
            var courses = await _dbContext.Courses
                .Include(x => x.Field)
                .ThenInclude(x => x.FacultyId)
                .Where(x => x.FieldId == id)
                .ToListAsync();

            
            return Ok(_mapper.Map<List<GetCourseViewModel>>(courses));
        }

        [HttpPost("add-course")]
        public async Task<IActionResult> AddCourse([FromBody]AddCourseDto courseDto)
        {
            var itExists = await _dbContext.Courses
                .AnyAsync(x => x.Name == courseDto.Name && x.FieldId == courseDto.FieldId);
            if (itExists)
            {
                return Ok(false);
            }

            var course = _mapper.Map<Course>(courseDto);
            await _dbContext.Courses.AddAsync(_mapper.Map<Course>(courseDto));
            await _dbContext.SaveChangesAsync();

            return Ok(course);
        }

    }
}
