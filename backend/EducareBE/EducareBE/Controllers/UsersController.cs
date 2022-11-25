using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.Password
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }
            
        [HttpGet]
        public IActionResult GetAllUsers()
        {

            return Ok(_dbContext.Users.ToList());
        }
    }
}
