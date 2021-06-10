using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreestyleApplication.Database;
using FreestyleApplication.Models;
using AutoMapper;
using FreestyleApplication.ViewModel;

namespace FreestyleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompetitionsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Competitions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionViewModel>>> GetCompetition()
        {
            return _mapper.Map<IEnumerable<CompetitionViewModel>>(await _context.Competition.ToListAsync()).ToList();
        }

        // GET: api/Competitions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionViewModel>> GetCompetition(int id)
        {
            var competition = await _context.Competition.FindAsync(id);

            if (competition == null)
            {
                return NotFound();
            }

            return _mapper.Map<CompetitionViewModel>(competition);
        }

        // PUT: api/Competitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetition(int id, CompetitionViewModel competition)
        {
            competition.Id = id;
            var competitionModel = _mapper.Map<Competition>(competition);

            _context.Entry(competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Competitions
        [HttpPost]
        public async Task<ActionResult<Competition>> PostCompetition(CompetitionViewModel competition)
        {
            var competitionModel = _mapper.Map<User>(competition);
            _context.Users.Add(competitionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = competitionModel.Id }, competition);
        }

        // DELETE: api/Competitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            var competition = await _context.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }

            _context.Competition.Remove(competition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competition.Any(e => e.Id == id);
        }

        [HttpGet("GetCompetitionsFromUser")]
        public async Task<ActionResult<IEnumerable<CompetitionViewModel>>> GetCompetitionsFromUser(int userId)
        {
            User user = await _context.Users.Include(x => x.Competitions).FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                return NotFound();
            IEnumerable<CompetitionViewModel> listCompetitionsViewModel = _mapper.Map<IEnumerable<CompetitionViewModel>>(user.Competitions);

            return listCompetitionsViewModel.ToList();
        }
    }
}
