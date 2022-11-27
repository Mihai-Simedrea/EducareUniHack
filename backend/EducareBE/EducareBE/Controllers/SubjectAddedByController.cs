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
    public class SubjectAddedByController : Controller
    {
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectAddedByController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSubjectsAddedBy(int id)
        {
            var subjectsAddedBy = await _dbContext.SubjectsAddedBy
                .Include(x => x.Subject)
                .Where(x => x.SubjectId == id)
                .ToListAsync();
            return Ok(_mapper.Map<List<GetAllSubjectsAddedByViewModel>>(subjectsAddedBy));
        }

        [HttpPost("{userId}/add-subject-added-by/{materialName}/for/{subjectId}")]
        public async Task<IActionResult> AddAllSubjectsAddedBy(int userId, string materialName, int subjectId)
        {
            var itExists = await _dbContext.SubjectsAddedBy
                .AnyAsync(x => x.Name == materialName && x.SubjectId == subjectId);
            if (itExists)
            {
                return Ok(false);
            }

            var subjectAddedBy = new SubjectAddedBy
            {
                UserId = userId,
                SubjectId = subjectId,
                Name = materialName,
            };

            await _dbContext.SubjectsAddedBy.AddAsync(subjectAddedBy);
            await _dbContext.SaveChangesAsync();

            return Ok(subjectAddedBy);
        }

        //[HttpPost("{id}/like")]
        //public async Task<IActionResult> LikeSubjectAddedBy(int id)
        //{
        //    var subjectAddedBy = await _dbContext.SubjectsAddedBy
        //        .Where(x => x.Id == id)
        //        .FirstOrDefaultAsync();

        //    //subjectAddedBy.Likes = subjectAddedBy.Likes += 1;
        //    // TODO:



        //    return Ok();
        //}

        //[HttpPost("{id}/dislike")]
        //public async Task<IActionResult> DislikeSubjectAddedBy(int id)
        //{

        //    return Ok();
        //}
    }
}
