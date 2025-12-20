namespace CareerRoadmapGenerator.Models.Entities
{
    public class UserCareerProgress
    {
        public int Id { get; set; }

        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }

        public int CareerId { get; set; }
        public int CompletedSteps { get; set; }

    }
}
