using CareerRoadmapGenerator.Models.DTOs;
using CareerRoadmapGenerator.Models.Entities;

namespace CareerRoadmapGenerator.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill?> GetSkillByIdAsync(int id);
        Task<Skill> CreateSkillAsync(SkillDto skillDto);
    }
}
