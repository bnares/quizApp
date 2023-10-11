using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly QuizDbContext _dbContext;

        public ParticipantsController(QuizDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
        {
            var temp = await _dbContext.Participants.Where(x => x.Name == participant.Name && x.Email == participant.Email).FirstOrDefaultAsync();
            if (temp == null)
            {
                await _dbContext.AddAsync(participant);
                await _dbContext.SaveChangesAsync();

            }
            else participant = temp;
            return Ok(participant);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,ParticipantDto dto)
        {
            //var participant = await _dbContext.Participants.FirstOrDefaultAsync(x=>x.ParticipantId==dto.ParticipantId);
            var participant = await _dbContext.Participants.FindAsync(id);
            if (participant==null || participant.ParticipantId != id) return BadRequest();
            participant.Score = dto.Score;
            participant.TimeTaken = dto.TimeTaken;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
