using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    public class EvaluatorConfiguration : IEntityTypeConfiguration<Evaluator>
    {
        public void Configure(EntityTypeBuilder<Evaluator> builder)
        {
            builder.HasKey(e => e.EvaluatorId);

            builder.HasIndex(e => e.EvaluationId);

            builder.HasOne(d => d.Evaluation)
                .WithMany(p => p.Evaluators)
                .HasForeignKey(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.EvaluatorEmail)
             .IsRequired()
             .HasMaxLength(150);

            builder.Property(e => e.IsSubmitted)
            .IsRequired();
        }
    }
}
