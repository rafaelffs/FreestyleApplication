using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreestyleApplication.Database;
using FreestyleApplication.Models;
using Newtonsoft.Json;
using FreestyleApplication.ViewModel;
using AutoMapper;

namespace FreestyleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _context.Users.ToListAsync()).ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            //var user = await _context.Users.Include(c => c.Competitions).FirstOrDefaultAsync(x => x.Id == id);
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserViewModel user)
        {
            user.Id = id;
            var userModel = _mapper.Map<User>(user);

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> PostUser(UserViewModel user)
        {
            var userModel = _mapper.Map<User>(user);
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = userModel.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        // POST: api/AddUserToCompetition
        [HttpPost("AddUserToCompetition")]
        public async Task<ActionResult> AddUserToCompetition(int competitionId, List<int> users)
        {
            Competition competition = await _context.Competitions.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == competitionId);

            if (competition == null)
                return NotFound();

            foreach (int userId in users)
            {
                if (!competition.Users.Any(x => x.Id == userId))
                {
                    var user = _context.Users.FirstOrDefault(x => x.Id == userId);
                    if (user == null)
                        return NotFound();
                    competition.Users.Add(user);
                }
            }
            _context.Entry(competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();

        }

        [HttpGet("GetUsersFromCompetition")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsersFromCompetition(int competitionId)
        {
            Competition competition = await _context.Competitions.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == competitionId);
            if (competition == null)
                return NotFound();
            IEnumerable<UserViewModel> listUsersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(competition.Users);

            return listUsersViewModel.ToList();
        }
    }
}
