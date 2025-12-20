using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CareerRoadmapGenerator.Models.Entities;


namespace CareerRoadmapGenerator.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Career> Careers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }

        public DbSet<UserCareerProgress> UserCareerProgresses { get; set; }
        public DbSet<ProjectIdea> ProjectIdeas { get; set; }
        public DbSet<Resource> Resources { get; set; }
        
    }
}
