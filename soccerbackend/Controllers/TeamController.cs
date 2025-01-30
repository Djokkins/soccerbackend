using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soccerbackend.Data;
using soccerbackend.Models;

namespace soccerbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly SoccerDbContext _context;

        public TeamsController(SoccerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _context.Teams.Include(t => t.Players).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeams), new { id = team.Id }, team);
        }
    }
}
