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
    public class ExerciseController: Controller
    {
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExerciseController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise(int id)
        {
            var exercises = await _dbContext.Exercises
                .Include(x => x.Subject)
                .Where(x => x.SubjectId == id)
                .ToListAsync();
            return Ok(exercises);
        }

        [HttpPost("{userId}/add-exercise/{exerciseName}/for/{subjectId}")]
        public async Task<IActionResult> AddExercise(int userId, string exerciseName, int subjectId)
        {
            var itExists = await _dbContext.SubjectsAddedBy
                .AnyAsync(x => x.Name == exerciseName && x.SubjectId == subjectId);
            if (itExists)
            {
                return Ok(false);
            }

            var exercise = new Exercise
            {
                UserId = userId,
                SubjectId = subjectId,
                Name = exerciseName,
            };

            await _dbContext.Exercises.AddAsync(exercise);
            await _dbContext.SaveChangesAsync();

            return Ok(exercise);
        }

    }
}
