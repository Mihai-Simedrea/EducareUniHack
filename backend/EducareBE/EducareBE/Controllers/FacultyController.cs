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
        public async Task<IActionResult> GetAllFaculties(int id)
        {
            var faculties = await _dbContext.Faculties
                .Where(x => x.UniversityId == id)
                .ToListAsync();
            return Ok(faculties);
        }

        [HttpPost("add-faculty/{id}")]
        public async Task<IActionResult> AddFaculty(int id, string facultyName)
        {
            var itExists = await _dbContext.Faculties
                .AnyAsync(x => x.Name == facultyName && x.UniversityId == id);
            if (itExists)
            {
                return Ok(false);
            }

            var faculty = new Faculty
            {
                UniversityId = id,
                Name = facultyName,
            };

            await _dbContext.Faculties.AddAsync(faculty);
            await _dbContext.SaveChangesAsync();

            return Ok(faculty);
        }

    }
}
