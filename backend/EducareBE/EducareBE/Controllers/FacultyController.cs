using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : Controller
    {

        public ApplicationDbContext _dbContext;

        public FacultyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllFaculties(int Id)
        {
            var faculties = await _dbContext.Universities
                .Where(x => x.Id == Id)
                .ToListAsync();
            return Ok(faculties);
        }

        [HttpPost("add-faculty")]
        public async Task<IActionResult> AddUniversity(string facultyName)
        {
            var itExists = await _dbContext.Faculties
                .AnyAsync(x => x.Name == facultyName);
            if (itExists)
            {
                return Ok(false);
            }

            var faculty = new Faculty
            {
                Name = facultyName,
            };

            await _dbContext.Faculties.AddAsync(faculty);
            await _dbContext.SaveChangesAsync();

            return Ok(faculty);
        }

    }
}
