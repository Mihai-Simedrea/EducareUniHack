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
            var subjectsAddedBy = await _dbContext.SubjectsAddedBy
                .Include(x => x.Subject)
                .Where(x => x.SubjectId == id)
                .ToListAsync();
            return Ok(subjectsAddedBy);
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

            var subjectAddedBy = new SubjectAddedBy
            {
                SubjectId = id,
                Name = subjectsAddedByName,
            };

            await _dbContext.SubjectsAddedBy.AddAsync(subjectAddedBy);
            await _dbContext.SaveChangesAsync();

            return Ok(subjectAddedBy);
        }

        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikeSubjectAddedBy(int id)
        {
            var subjectAddedBy = await _dbContext.SubjectsAddedBy
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            //subjectAddedBy.Likes = subjectAddedBy.Likes += 1;
            // TODO:



            return Ok();
        }

        [HttpPost("{id}/dislike")]
        public async Task<IActionResult> DislikeSubjectAddedBy(int id)
        {

            return Ok();
        }
    }
}
