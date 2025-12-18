namespace CareerRoadmapGenerator.Models
{
    public partial class UserProgress
    {
        public int UserProgressId { get; set; }

        public int? UserId { get; set; } // if you have a User model
        public int? CareerId { get; set; }
        public int? SkillId { get; set; }

        public int? ProgressPercentage { get; set; }

        // Navigation
        public virtual Career? Career { get; set; }
        public virtual Skill? Skill { get; set; }
        // public virtual User? User { get; set; } // uncomment if you have User model
    }
}