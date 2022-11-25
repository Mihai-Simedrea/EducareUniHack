using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : Controller
    {public ApplicationDbContext _dbContext;

        public UniversityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAllUniveristies()
        {
            var universites = await _dbContext.Universities.ToListAsync();
            return Ok(universites);
        }

        [HttpPost]
        public async Task<IActionResult> AddUniversity(string UnivesrityName)
        {
            var itExists = await _dbContext.Users
                .AnyAsync(x => x.Email == UnivesrityName);
            if (itExists)
            {
                return Ok(false);
            }

            var university = new University
            {
                Name  = UnivesrityName,
            };

            await _dbContext.Universities.AddAsync(university);
            await _dbContext.SaveChangesAsync();

            return Ok(university);
        }

    }
}
