using CareerRoadmapGenerator.Data;
using CareerRoadmapGenerator.Models.DTOs;
using CareerRoadmapGenerator.Models.Entities;
using CareerRoadmapGenerator.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CareerRoadmapGenerator.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext _context;

        public SkillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill?> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<Skill> CreateSkillAsync(SkillDto skillDto)
        {
            var skill = new Skill
            {
                Name = skillDto.Name,
                Description = skillDto.Description,
                Level = skillDto.Level
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill;
        }
    }
}
