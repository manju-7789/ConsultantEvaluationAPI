using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    class TechAreaNotesConfiguration : IEntityTypeConfiguration<TechAreaRecommendation>
    {
        public void Configure(EntityTypeBuilder<TechAreaRecommendation> builder)
        {
            builder.HasIndex(e => e.EvaluatorId);

            builder.HasIndex(e => e.TechId);

            builder.HasOne(d => d.Evaluator)
                .WithMany(p => p.TechAreaRecommendation)
                .HasForeignKey(d => d.EvaluatorId);

            builder.HasOne(d => d.Tech)
                .WithMany(p => p.TechAreaRecommendation)
                .HasForeignKey(d => d.TechId);

            builder.Property(e => e.RecommendationNotes)
           .HasMaxLength(150);
        }
    }
}
