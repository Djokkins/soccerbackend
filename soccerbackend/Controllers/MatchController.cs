using Microsoft.AspNetCore.Mvc;
using soccerbackend.Data;

namespace soccerbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            _context.Matches.Add(match);

            foreach (var player in match.Winner.Players)
            {
                player.Handicap += 1;
            }
            foreach (var player in match.Loser.Players)
            {
                player.Handicap -= 1;
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostMatch), new { id = match.Id }, match);
        }
    }
}
