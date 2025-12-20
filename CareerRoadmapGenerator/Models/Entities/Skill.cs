using System.Collections.Generic;

namespace CareerRoadmapGenerator.Models.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            Resources = new HashSet<Resource>();
            UserProgresses = new HashSet<UserProgress>();
            ProjectIdeas = new HashSet<ProjectIdea>();
        }

        // Primary key expected by code
        public int SkillId { get; set; }

        // Name / display fields
        public string Name { get; set; }
        public string Description { get; set; }

        // Properties referenced by your code
        public string Level { get; set; }      // e.g., Beginner/Intermediate/Advanced
        public int Order { get; set; }         // ordering within a career

        // FK to Career
        public int CareerId { get; set; }

        // Navigation properties
        public virtual Career? Career { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<UserProgress> UserProgresses { get; set; }
        public virtual ICollection<ProjectIdea> ProjectIdeas { get; set; }
    }
}