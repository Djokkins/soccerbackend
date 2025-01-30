﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soccerbackend.Data;
using soccerbackend.Models;

namespace soccerbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly SoccerDbContext _context;

        public MatchesController(SoccerDbContext context)
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
        [HttpPut]
        public async Task<ActionResult<Match>> PutMatch(int matchid, int winnerid)
        {
            var match = _context.Matches.Where(m => m.Id == matchid).SingleAsync();
            //match.WinnerId = winnerid;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PutMatch), new { id = match.Id }, match);
        }
    }
}
