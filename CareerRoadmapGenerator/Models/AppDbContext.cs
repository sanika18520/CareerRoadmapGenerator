using Microsoft.EntityFrameworkCore;

namespace CareerRoadmapGenerator.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Career> Careers { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<UserProgress> UserProgresses { get; set; } = null!;
        public virtual DbSet<ProjectIdea> ProjectIdeas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // keep your local connection (you can move to configuration later)
                optionsBuilder.UseSqlServer("Server=LAPTOP-DI8TCENN\\SQLEXPRESS;Database=CareerRoadmapDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Career
            modelBuilder.Entity<Career>(entity =>
            {
                entity.HasKey(e => e.CareerId);
                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(2000);
            });

            // Skill
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.SkillId);
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.Level).HasMaxLength(100);

                entity.HasOne(d => d.Career)
                      .WithMany(p => p.Skills)
                      .HasForeignKey(d => d.CareerId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // ProjectIdea
            modelBuilder.Entity<ProjectIdea>(entity =>
            {
                entity.HasKey(e => e.ProjectIdeaId);
                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Difficulty).HasMaxLength(50);

                entity.HasOne(d => d.Career)
                      .WithMany(p => p.ProjectIdeas)
                      .HasForeignKey(d => d.CareerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Skill)
                      .WithMany(p => p.ProjectIdeas)
                      .HasForeignKey(d => d.SkillId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Resource
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);
                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Url).HasMaxLength(1000);

                entity.HasOne(d => d.Career)
                      .WithMany(p => p.Resources)
                      .HasForeignKey(d => d.CareerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Skill)
                      .WithMany(p => p.Resources)
                      .HasForeignKey(d => d.SkillId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // UserProgress
            modelBuilder.Entity<UserProgress>(entity =>
            {
                entity.HasKey(e => e.UserProgressId);

                entity.HasOne(d => d.Career)
                      .WithMany(p => p.UserProgresses)
                      .HasForeignKey(d => d.CareerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Skill)
                      .WithMany(p => p.UserProgresses)
                      .HasForeignKey(d => d.SkillId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}