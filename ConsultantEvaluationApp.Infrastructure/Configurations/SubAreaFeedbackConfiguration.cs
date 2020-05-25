using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    class SubAreaFeedbackConfiguration : IEntityTypeConfiguration<SubAreaFeedback>
    {
        public void Configure(EntityTypeBuilder<SubAreaFeedback> builder)
        {
            builder.HasIndex(e => e.EvaluatorId);

            builder.HasIndex(e => e.SubTechId);

            builder.HasOne(d => d.Evaluator)
                .WithMany(p => p.SubAreaFeedback)
                .HasForeignKey(d => d.EvaluatorId);

            builder.HasOne(d => d.SubTech)
                .WithMany(p => p.SubAreaFeedback)
                .HasForeignKey(d => d.SubTechId);

            builder.Property(e => e.FeedbackNotes)
            .HasMaxLength(150);
        }
    }
}
