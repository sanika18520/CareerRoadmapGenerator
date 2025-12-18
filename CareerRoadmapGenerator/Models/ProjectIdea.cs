namespace CareerRoadmapGenerator.Models
{
    public partial class ProjectIdea
    {
        // Primary key
        public int ProjectIdeaId { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        // Property referenced in your errors
        public string? Difficulty { get; set; } // e.g., Easy/Medium/Hard

        // FKs
        public int? CareerId { get; set; }
        public int? SkillId { get; set; }

        // Navigation
        public virtual Career? Career { get; set; }
        public virtual Skill? Skill { get; set; }
    }
}