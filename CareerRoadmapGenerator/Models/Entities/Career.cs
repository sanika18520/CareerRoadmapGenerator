using System.Collections.Generic;

namespace CareerRoadmapGenerator.Models.Entities

{
    public partial class Career
    {
        public Career()
        {
            Skills = new HashSet<Skill>();
            ProjectIdeas = new HashSet<ProjectIdea>();
            Resources = new HashSet<Resource>();
            UserProgresses = new HashSet<UserProgress>();
        }

        // Primary key expected across the codebase
        public int CareerId { get; set; }

        // Common display/title field other code refers to
        public string? Title { get; set; }
        public string? Description { get; set; }

        // Navigation collections your views/controllers expect
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<ProjectIdea> ProjectIdeas { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<UserProgress> UserProgresses { get; set; }
    }
}