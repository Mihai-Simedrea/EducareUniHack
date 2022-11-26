using AutoMapper;
using EducareBE.Data;
using EducareBE.Models.DtoModels;
using EducareBE.Models.Entities;
using EducareBE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : Controller
    {

        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FacultyController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllFaculties(int id)
        {
            var faculties = await _dbContext.Faculties
                .Include(x => x.Fields)
                .Where(x => x.UniversityId == id)
                .ToListAsync();

            return Ok(_mapper.Map<List<GetFacultiesViewModel>>(faculties));
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

            // _dbContext.Universities.First(x => x.Id == id).Faculties.Add(faculty);

            await _dbContext.Faculties.AddAsync(faculty);
            await _dbContext.SaveChangesAsync();

            return Ok(faculty);
        }

    }
}
