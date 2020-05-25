using ConsultantEvaluationApp.Application.Common.Interfaces;
using ConsultantEvaluatonApp.Domain.Common;
using ConsultantEvaluatonApp.Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        public ApplicationDbContext(
            DbContextOptions options,
             IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<EvaluationProcess> EvaluationProcesses { get; set; }
        public DbSet<EvaluationTechnology> EvaluationTechnologies { get; set; }
        public DbSet<Evaluator> Evaluators { get; set; }
        public DbSet<SubAreaFeedback> SubAreaFeedbacks { get; set; }
        public DbSet<TechAreaRecommendation> TechAreaRecommendations { get; set; }
        public DbSet<TechnologyArea> TechnologyAreas { get; set; }
        public DbSet<TechSubArea> TechSubAreas { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
