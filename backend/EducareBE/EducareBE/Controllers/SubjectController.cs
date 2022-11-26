using AutoMapper;
using EducareBE.Data;
using EducareBE.Models.Entities;
using EducareBE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSubjects(int id)
        {
            var subjects = await _dbContext.Subjects
                .Include(x => x.Course)
                .Where(x => x.CourseId == id)
                .ToListAsync();
            return Ok(_mapper.Map<GetAllSubjectsDto>(subjects));
        }

        [HttpPost("add-subject/{id}")]
        public async Task<IActionResult> AddSubject(int id, string subjectName)
        {
            var itExists = await _dbContext.Subjects
                .AnyAsync(x => x.Name == subjectName && x.CourseId == id);
            if (itExists)
            {
                return Ok(false);
            }

            var subject = new Subject
            {
                CourseId = id,
                Name = subjectName,
            };

            await _dbContext.Subjects.AddAsync(subject);
            await _dbContext.SaveChangesAsync();

            return Ok(subject);
        }

    }
}
