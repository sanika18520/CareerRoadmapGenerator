namespace CareerRoadmapGenerator.Models.DTOs
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public int Order { get; set; }
        public int CareerId { get; set; }
        public string? CareerTitle { get; set; }
    }
}
