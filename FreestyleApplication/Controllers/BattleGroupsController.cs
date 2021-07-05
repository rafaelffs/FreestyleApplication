using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreestyleApplication.Database;
using FreestyleApplication.Models;

namespace FreestyleApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BattleGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BattleGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BattleGroup>>> GetBattleGroups()
        {
            return await _context.BattleGroups.ToListAsync();
        }

        // GET: api/BattleGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BattleGroup>> GetBattleGroup(int id)
        {
            var battleGroup = await _context.BattleGroups.FindAsync(id);

            if (battleGroup == null)
            {
                return NotFound();
            }

            return battleGroup;
        }

        // PUT: api/BattleGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattleGroup(int id, BattleGroup battleGroup)
        {
            if (id != battleGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(battleGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleGroupExists(id))
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

        // POST: api/BattleGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BattleGroup>> PostBattleGroup(BattleGroup battleGroup)
        {
            _context.BattleGroups.Add(battleGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattleGroup", new { id = battleGroup.Id }, battleGroup);
        }

        // DELETE: api/BattleGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattleGroup(int id)
        {
            var battleGroup = await _context.BattleGroups.FindAsync(id);
            if (battleGroup == null)
            {
                return NotFound();
            }

            _context.BattleGroups.Remove(battleGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BattleGroupExists(int id)
        {
            return _context.BattleGroups.Any(e => e.Id == id);
        }

        [HttpPost("GenerateBattlesByGroup")]
        public async Task<ActionResult> GenerateBattlesByGroup(int groupId)
        {
            Group group = await _context.Groups
                .Include(u => u.Users)
                    .FirstOrDefaultAsync(x => x.Id == groupId);

            List<BattleGroup> list = new List<BattleGroup>();

            for (int i = 0; i < group.Users.Count; i++)
            {
                for (int y = i + 1; y < group.Users.Count; y++)
                {
                    BattleGroup battleGroup = new BattleGroup();
                    battleGroup.Users = new List<User>();
                    battleGroup.Group = group;
                    battleGroup.Users.Add(group.Users[i]);
                    battleGroup.Users.Add(group.Users[y]);
                    list.Add(battleGroup);
                }
            }

            foreach (BattleGroup bg in list)
            {
                await PostBattleGroup(bg);
            }

            return Ok();
        }
    }
}
