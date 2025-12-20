namespace CareerRoadmapGenerator.Models.Entities
{
    public partial class Resource
    {
        // Primary key
        public int ResourceId { get; set; }

        // Common fields
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; } // e.g., Article, Video, Course

        // FKs
        public int? SkillId { get; set; }
        public int? CareerId { get; set; }

        // Navigation
        public virtual Skill? Skill { get; set; }
        public virtual Career? Career { get; set; }
    }
}