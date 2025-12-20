using Microsoft.AspNetCore.Identity;
namespace CareerRoadmapGenerator.Models.Entities

{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
