using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    public class EvaluationTechConfiguration : IEntityTypeConfiguration<EvaluationTechnology>
    {
        public void Configure(EntityTypeBuilder<EvaluationTechnology> builder)
        {
            builder.HasIndex(e => e.EvaluationId);

            builder.HasIndex(e => e.TechId);

            builder.HasOne(d => d.Evaluation)
                .WithMany(p => p.EvaluationTechnologies)
                .HasForeignKey(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.TechnologyArea)
                .WithMany(p => p.EvaluationTechnology)
                .HasForeignKey(d => d.TechId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
