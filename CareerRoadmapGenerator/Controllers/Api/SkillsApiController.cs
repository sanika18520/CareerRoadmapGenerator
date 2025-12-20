using CareerRoadmapGenerator.Data;
using CareerRoadmapGenerator.Models.Entities;
using CareerRoadmapGenerator.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareerRoadmapGenerator.Controllers.Api
{
    [Authorize]
    [ApiController]
    [Route("api/skills")]
    public class SkillsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SkillsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkills()
        {
            var skills = await _context.Skills
                .Include(s => s.Career)
                .ToListAsync();

            var skillDtos = skills.Select(s => new SkillDto
            {
                SkillId = s.SkillId,
                Name = s.Name,
                Description = s.Description,
                Level = s.Level,
                Order = s.Order,
                CareerId = s.CareerId,
                CareerTitle = s.Career?.Title
            });

            return Ok(skillDtos);
        }

        // GET: api/skills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var skill = await _context.Skills
                .Include(s => s.Career)
                .FirstOrDefaultAsync(s => s.SkillId == id);

            if (skill == null)
                return NotFound();

            return Ok(skill);
        }

        // POST: api/skills
        [HttpPost]
        public async Task<ActionResult<SkillDto>> PostSkill(SkillDto skillDto)
        {
            var skill = new Skill
            {
                Name = skillDto.Name,
                Description = skillDto.Description,
                Level = skillDto.Level,
                Order = skillDto.Order,
                CareerId = skillDto.CareerId
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            skillDto.SkillId = skill.SkillId;
            skillDto.CareerTitle = (await _context.Careers.FindAsync(skill.CareerId))?.Title;

            return CreatedAtAction(nameof(GetSkills), new { id = skill.SkillId }, skillDto);
        }


        // PUT: api/skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Skill skill)
        {
            if (id != skill.SkillId)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
                return NotFound();

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
