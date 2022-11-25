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
        public async Task<IActionResult> LogIn(UserLoginDto request)
        {

            var itExists = await _dbContext.Users
                .AnyAsync(x => x.Email == request.Email && x.Password == request.Password);

            return Ok(itExists);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {

            return Ok(_dbContext.Users.ToList());
        }
    }
}
