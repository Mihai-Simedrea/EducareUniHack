using EducareBE.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
