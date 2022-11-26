﻿using AutoMapper;
using EducareBE.Data;
using EducareBE.Models.Entities;
using EducareBE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UniversityController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet("get-all-universities")]
        public async Task<IActionResult> GetAllUniveristies()
        {
            var universites = await _dbContext.Universities.Include(x => x.Faculties).ToListAsync();
            return Ok(_mapper.Map<List<GetUniversityViewModel>>(universites));
        }

        [HttpGet("get-all-universities-by-name/{universityName}")]
        public async Task<IActionResult> GetAllUniversitiesByName(string universityName)
        {
            var universities =
                await _dbContext.Universities.Include(x => x.Faculties)
                .Where(x => x.Name.Contains(universityName))
                .ToListAsync();


            return Ok(_mapper.Map<List<GetUniversityViewModel>>(universities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUniverstityById(int id)
        {
            var university = await _dbContext.Universities
                .Include(x => x.Faculties)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(university);
        }

        [HttpPost("add-university")]
        public async Task<IActionResult> AddUniversity(string univesrityName)
        {
            var itExists = await _dbContext.Universities
                .AnyAsync(x => x.Name == univesrityName);
            if (itExists)
            {
                return Ok(false);
            }

            var university = new University
            {
                Name = univesrityName,
            };

            await _dbContext.Universities.AddAsync(university);
            await _dbContext.SaveChangesAsync();

            return Ok(university);
        }

    }
}
