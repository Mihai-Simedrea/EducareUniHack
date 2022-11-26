using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        public ApplicationDbContext _dbContext;

        public ProfileController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{userEmail}")]
        public IActionResult GetProfile(string userEmail)
        {
            return Ok(_dbContext.Profiles.Where(x => x.User.Email == userEmail));
        }

        [HttpPost("profile/{id}")]
        public async Task<IActionResult> CreateProfile(int id, ProfileDto request)
        {
            var profile = new Profile
            {
                UserId = id,
                UniversityName = request.UniversityName,
                FieldName = request.FieldName,
                FacultyName = request.FacultyName,
                StudyYear = request.StudyYear
            };

            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();

            return Ok(true);
        }

    }
}
