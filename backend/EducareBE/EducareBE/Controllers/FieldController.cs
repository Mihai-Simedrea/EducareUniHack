using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldController : Controller
    {
        public ApplicationDbContext _dbContext;

        public FieldController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllFields(int id)
        {
            var fields = await _dbContext.Fields
                .Include(x => x.Courses)
                .Where(x => x.FacultyId == id)
                .ToListAsync();
            return Ok(fields);
        }

        [HttpPost("add-field/{id}")]
        public async Task<IActionResult> AddField(int id, string fieldName)
        {
            var itExists = await _dbContext.Fields
                .AnyAsync(x => x.Name == fieldName && x.FacultyId == id);
            if (itExists)
            {
                return Ok(false);
            }

            var field = new Field
            {
                FacultyId = id,
                Name = fieldName,
            };

            await _dbContext.Fields.AddAsync(field);
            await _dbContext.SaveChangesAsync();

            return Ok(field);
        }
    }
}
