using EducareBE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseCoutnroller : Controller
    {    
        public ApplicationDbContext _dbContext;

        public CourseCoutnroller(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
