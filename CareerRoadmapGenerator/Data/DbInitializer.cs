using System.Linq;
using CareerRoadmapGenerator.Models;

namespace CareerRoadmapGenerator.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Careers.Any()) return; // already seeded

            var career = new Career { Title = ".NET Developer", Description = "Backend & Web dev using C# and ASP.NET Core" };
            context.Careers.Add(career);
            context.SaveChanges();

            context.Skills.AddRange(
                new Skill { Name = "C# Basics", Level = "Beginner", Order = 1, CareerId = career.CareerId },
                new Skill { Name = "OOP", Level = "Beginner", Order = 2, CareerId = career.CareerId },
                new Skill { Name = "ASP.NET Core MVC", Level = "Intermediate", Order = 1, CareerId = career.CareerId },
                new Skill { Name = "Entity Framework Core", Level = "Intermediate", Order = 2, CareerId = career.CareerId },
                new Skill { Name = "Web API & REST", Level = "Advanced", Order = 1, CareerId = career.CareerId }
            );

            context.ProjectIdeas.Add(new ProjectIdea { Title = "Career Roadmap Generator", Description = "Build the roadmap app", Difficulty = "Intermediate", CareerId = career.CareerId });
            context.Resources.AddRange(
                new Resource { Title = "MS Docs: ASP.NET Core", Url = "https://learn.microsoft.com/aspnet/core", Type = "Docs", CareerId = career.CareerId },
                new Resource { Title = "EF Core Docs", Url = "https://learn.microsoft.com/ef/core", Type = "Docs", CareerId = career.CareerId }
            );

            context.SaveChanges();

        }
    }
}
