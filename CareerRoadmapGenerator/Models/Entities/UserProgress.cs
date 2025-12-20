namespace CareerRoadmapGenerator.Models.Entities
{
    public class UserProgress
    {
        public int UserProgressId { get; set; }

        public required string UserId { get; set; } // Must be string
        public required ApplicationUser User { get; set; }

        public int CareerId { get; set; }
        public required Career Career { get; set; }

        public int SkillId { get; set; }
        public required Skill Skill { get; set; }

        public int ProgressPercentage { get; set; }
    }
}