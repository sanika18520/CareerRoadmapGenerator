using CareerRoadmapGenerator.Data;
using CareerRoadmapGenerator.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CareerRoadmapGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProgressesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserProgressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserProgresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCareerProgress>>> GetUserProgresses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            var data = await _context.UserCareerProgresses
                                 .Where(p => p.UserId == userId)
                                 .ToListAsync();
            return Ok(data);
        }

        // GET: api/UserProgresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCareerProgress>> GetUserProgress(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _context.UserCareerProgresses
                                         .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (progress == null)
            {
                return NotFound();
            }

            return progress;
        }

        // POST: api/UserProgresses
        [HttpPost]
        public async Task<ActionResult<UserCareerProgress>> PostUserProgress(UserCareerProgress progress)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }
            progress.UserId = userId;

            _context.UserCareerProgresses.Add(progress);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserProgress), new { id = progress.Id }, progress);
        }
        // PUT: api/UserProgresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProgress(int id, UserCareerProgress progress)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != progress.Id || progress.UserId != userId)
            {
                return BadRequest();
            }

            _context.Entry(progress).State = EntityState.Modified;
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProgressExists(id, userId))
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();
        }

        // DELETE: api/UserProgresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProgress(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var progress = await _context.UserCareerProgresses
                                         .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (progress == null)
            {
                return NotFound();
            }

            _context.UserCareerProgresses.Remove(progress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserProgressExists(int id, string userId)
        {
            return _context.UserCareerProgresses.Any(e => e.Id == id && e.UserId == userId);
        }
    }
}
