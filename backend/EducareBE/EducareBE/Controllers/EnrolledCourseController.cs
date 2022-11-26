using AutoMapper;
using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolledCourseController : Controller
    {
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EnrolledCourseController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("{userId}/add-to-favorites/{courseId}")]
        public async Task<IActionResult> AddToFavorites(int userId, int courseId)
        {
            EnrolledCourses? enrolledCourse;
            enrolledCourse = await _dbContext.EnrolledCourses
              .FirstOrDefaultAsync(x => x.CourseId == courseId && x.UserId == userId);

            if (enrolledCourse == null)
            {
                enrolledCourse = new EnrolledCourses
                {
                    UserId = userId,
                    CourseId = courseId,
                    IsFavoirte = true
                };
            }

            enrolledCourse.IsFavoirte = true;

            await _dbContext.EnrolledCourses.AddAsync(enrolledCourse);
            await _dbContext.SaveChangesAsync();

            return Ok(enrolledCourse);
        }

        [HttpPost("{userId}/enroll/{courseId}")]
        public async Task<IActionResult> AddField(int userId, int courseId)
        {
            EnrolledCourses? enrolledCourse;
            enrolledCourse = await _dbContext.EnrolledCourses
              .FirstOrDefaultAsync(x => x.CourseId == courseId && x.UserId == userId);

            if (enrolledCourse == null)
            {
                enrolledCourse = new EnrolledCourses
                {
                    UserId = userId,
                    CourseId = courseId,
                    IsEnrolled = true
                };
            }

            enrolledCourse.IsEnrolled = true;

            await _dbContext.EnrolledCourses.AddAsync(enrolledCourse);
            await _dbContext.SaveChangesAsync();

            return Ok(enrolledCourse);
        }

        [HttpGet("{userId}/favorites")]
        public async Task<IActionResult> GetFavorites(int userId)
        {
            var allFavoriteCourses = await _dbContext.EnrolledCourses
              .Where(x => x.UserId == userId && x.IsFavoirte == true)
              .ToListAsync();

            return Ok(allFavoriteCourses);
        }

        [HttpGet("{userId}/enrolled")]
        public async Task<IActionResult> GetEnrolled(int userId)
        {
            var allFavoriteCourses = await _dbContext.EnrolledCourses
              .Where(x => x.UserId == userId && x.IsEnrolled == true)
              .ToListAsync();

            return Ok(allFavoriteCourses);
        }

    }
}
