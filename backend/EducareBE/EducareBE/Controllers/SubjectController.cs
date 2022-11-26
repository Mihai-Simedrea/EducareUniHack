using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        public ApplicationDbContext _dbContext;

        public SubjectController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSubjects(int id)
        {
            var subjects = await _dbContext.Subjects
                .Include(x => x.Course)
                .Where(x => x.CourseId == id)
                .ToListAsync();
            return Ok(subjects);
        }

        [HttpPost("add-subject/{id}")]
        public async Task<IActionResult> AddSubject(int id, string subjectName)
        {
            var itExists = await _dbContext.Subjects
                .AnyAsync(x => x.Name == subjectName && x.CourseId == id);
            if (itExists)
            {
                return Ok(false);
            }

            var subject = new Subject
            {
                CourseId = id,
                Name = subjectName,
            };

            await _dbContext.Subjects.AddAsync(subject);
            await _dbContext.SaveChangesAsync();

            return Ok(subject);
        }

    }
}
