using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsultantEvaluationApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess> EvaluationProcesses { get; set; }

        public DbSet<EvaluationTechnology> EvaluationTechnologies { get; set; }

        public DbSet<Evaluator> Evaluators { get; set; }
        public DbSet<SubAreaFeedback> SubAreaFeedbacks { get; set; }
        public DbSet<TechAreaRecommendation> TechAreaRecommendations { get; set; }
        public DbSet<TechnologyArea> TechnologyAreas { get; set; }
        public DbSet<TechSubArea> TechSubAreas { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
