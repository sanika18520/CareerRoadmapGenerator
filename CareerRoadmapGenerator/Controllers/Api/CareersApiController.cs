using CareerRoadmapGenerator.Data;
using CareerRoadmapGenerator.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerRoadmapGenerator.Controllers.Api
{
    [Authorize]
    [ApiController]
    [Route("api/careers")]
    public class CareersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CareersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/careers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var careers = await _context.Careers
                .Include(c => c.Skills)
                .ToListAsync();

            return Ok(careers);
        }

        // GET: api/careers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var career = await _context.Careers
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.CareerId == id);

            if (career == null)
                return NotFound();

            return Ok(career);
        }

        // POST: api/careers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Career career)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Careers.Add(career);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = career.CareerId }, career);
        }

        // PUT: api/careers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Career career)
        {
            if (id != career.CareerId)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(career).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/careers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            if (career == null)
                return NotFound();

            _context.Careers.Remove(career);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
