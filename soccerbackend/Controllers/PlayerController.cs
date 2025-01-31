using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soccerbackend.Data;
using soccerbackend.Models;

namespace soccerbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly SoccerDbContext _context;

        public PlayersController(SoccerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.OrderByDescending(p => p.Handicap).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }


        [HttpGet("(Findplayer)")]
        public async Task<ActionResult<List<Player>>> GetPlayerByNameOrInitials(
            [FromQuery] string? name,
            [FromQuery] string? initials)
        {
            if(name == null && initials == null)
            {
                return BadRequest("name or initials must be provided");
            }

            List<Player> players = await _context.Players.Select(p => p).Where(p => p.Name == name || p.Initials == initials).ToListAsync();

            if (players == null)
            {
                return NotFound();
            }

            return players;
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(
            [FromQuery] string name,
            [FromQuery] string initials,
            [FromQuery] int handicap)
        {
            Player player = new Player(name, initials, handicap);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
          

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }


    }
}
