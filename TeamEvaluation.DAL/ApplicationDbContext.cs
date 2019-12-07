using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Grade> Grades{ get; set; }
        public DbSet<ProjectCriteria> ProjectsCriterias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectCriteria>()
                .HasKey(pc => new { pc.ProjectId, pc.CriteriaId });
            modelBuilder.Entity<ProjectCriteria>()
                .HasOne(pc => pc.Project)
                .WithMany(p => p.ProjectsCriterias)
                .HasForeignKey(bc => bc.ProjectId);
            modelBuilder.Entity<ProjectCriteria>()
                .HasOne(pc => pc.Criteria)
                .WithMany(c => c.ProjectsCriterias)
                .HasForeignKey(bc => bc.CriteriaId);
        }
    }
}
