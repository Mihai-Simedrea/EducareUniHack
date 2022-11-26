using AutoMapper;
using EducareBE.Data;
using EducareBE.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : Controller
    {
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public LikeController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("get-number-of-likes/{materialId}")]
        public IActionResult GetNumberOfLikesForUser(int materialId)
        {
            return Ok(_dbContext.Likes.Where(x => x.SubjectAddedById == materialId && x.LikesCount == 1)
                .ToList().Count);
        }

        [HttpGet("get-number-of-dislikes/{materialId}")]
        public IActionResult GetNumberOfDislikesForUser(int materialId)
        {
            return Ok(_dbContext.Likes.Where(x => x.SubjectAddedById == materialId && x.DislikesCount == 1)
                .ToList().Count);
        }

        [HttpPost("{userId}/like/{materialId}")]
        public async Task<IActionResult> LikeMaterial(int userId, int materialId)
        {
            Like? like;
            like = await _dbContext.Likes
              .FirstOrDefaultAsync(x => x.SubjectAddedById == materialId && x.UserId == userId);

            if (like == null)
            {
                like = new Like
                {
                    UserId = userId,
                    SubjectAddedById = materialId
                };
                await _dbContext.Likes.AddAsync(like);
            }

            if (like.DislikesCount == 0)
            {
                like.LikesCount = 1;
            }
            // _dbContext.Entry(enrolledCourse).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return Ok(like);
        }

        [HttpPost("{userId}/dislike/{materialId}")]
        public async Task<IActionResult> DislikeMaterial(int userId, int materialId)
        {
            Like? like;
            like = await _dbContext.Likes
              .FirstOrDefaultAsync(x => x.SubjectAddedById == materialId && x.UserId == userId);

            if (like == null)
            {
                like = new Like
                {
                    UserId = userId,
                    SubjectAddedById = materialId
                };
                await _dbContext.Likes.AddAsync(like);
            }
            if (like.LikesCount == 0)
            {
                like.DislikesCount = 1;
            }
            // _dbContext.Entry(enrolledCourse).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return Ok(like);
        }

    }
}
