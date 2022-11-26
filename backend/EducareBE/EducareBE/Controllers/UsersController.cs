using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {

            var itExists = await _dbContext.Users
               .AnyAsync(x => x.Email == request.Email && x.Password == request.Password);
            if (itExists)
            {
                return Ok(false); 
            }

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return Ok(true);
        }

        [HttpPost("login")]
        public IActionResult LogIn(UserLoginDto request)
        {
            var user = _dbContext.Users
                .Where(x => x.Email == request.Email && x.Password == request.Password)
                .FirstOrDefault();

            var resultId = -1;
            if (user == null)
            {
                resultId = -1;
            }

            resultId = user.Id;
            return Ok(resultId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.Include(x => x.Profile).ToListAsync();
            return Ok(users);
        }

        [HttpGet("get-user-by-email")]
        public async Task<IActionResult> GetUserByEmail(string Email)
        {
            var user = _dbContext.Users
                .Include(x => x.Profile)
                .Where(x => x.Email == Email)
                .First();

            return Ok(user);
        }
    }
}
