using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseCoutnroller : Controller
    {    
        public ApplicationDbContext _dbContext;

        public CourseCoutnroller(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCourses(int id)
        {
            var courses = await _dbContext.Courses
                .Where(x => x.FieldId == id)
                .ToListAsync();
            return Ok(courses);
        }

        [HttpPost("add-course/{id}")]
        public async Task<IActionResult> AddFaculty(int id, string courseName)
        {
            var itExists = await _dbContext.Courses
                .AnyAsync(x => x.Name == courseName && x.FieldId == id);
            if (itExists)
            {
                return Ok(false);
            }

            var course = new Course
            {
                FieldId = id,
                Name = courseName,
            };

            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return Ok(course);
        }

    }
}
