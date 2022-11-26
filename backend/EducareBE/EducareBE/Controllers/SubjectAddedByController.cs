using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectAddedByController : Controller
    {
        public ApplicationDbContext _dbContext;

        public SubjectAddedByController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSubjectsAddedBy(int id)
        {
            var fields = await _dbContext.SubjectsAddedBy
                .Include(x => x.Subject)
                .Where(x => x.SubjectId == id)
                .ToListAsync();
            return Ok(fields);
        }

        [HttpPost("add-subject-added-by/{id}")]
        public async Task<IActionResult> AddAllSubjectsAddedBy(int id, string subjectsAddedByName)
        {
            var itExists = await _dbContext.SubjectsAddedBy
                .AnyAsync(x => x.Name == subjectsAddedByName && x.SubjectId == id);
            if (itExists)
            {
                return Ok(false);
            }

            var subjectsAddedBy = new SubjectAddedBy
            {
                SubjectId = id,
                Name = subjectsAddedByName,
            };

            await _dbContext.SubjectsAddedBy.AddAsync(subjectsAddedBy);
            await _dbContext.SaveChangesAsync();

            return Ok(subjectsAddedBy);

        }
    }
}
