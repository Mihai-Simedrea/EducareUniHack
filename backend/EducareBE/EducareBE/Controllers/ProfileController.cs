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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var profile = await _dbContext.Profiles.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return Ok(profile);
        }

        [HttpPost("profile/{userId}")]
        public async Task<IActionResult> CreateProfile(int userId, ProfileDto request)
        {
            var profile = new Profile
            {
                UserId = userId,
                UniversityName = request.UniversityName,
                FieldName = request.FieldName,
                FacultyName = request.FacultyName,
                StudyYear = request.StudyYear
            };

            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();

            return Ok(profile.UserId);
        }

    }
}
