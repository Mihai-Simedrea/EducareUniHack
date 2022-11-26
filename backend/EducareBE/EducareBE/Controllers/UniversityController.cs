using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : Controller
    {
        public ApplicationDbContext _dbContext;

        public UniversityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUniveristies()
        {
            var universites = await _dbContext.Universities.Include(x => x.Faculties).ToListAsync();
            return Ok(universites);
        }

        [HttpPost("add-university")]
        public async Task<IActionResult> AddUniversity(string univesrityName)
        {
            var itExists = await _dbContext.Universities
                .AnyAsync(x => x.Name == univesrityName);
            if (itExists)
            {
                return Ok(false);
            }

            var university = new University
            {
                Name = univesrityName,
            };

            await _dbContext.Universities.AddAsync(university);
            await _dbContext.SaveChangesAsync();

            return Ok(university);
        }

    }
}
