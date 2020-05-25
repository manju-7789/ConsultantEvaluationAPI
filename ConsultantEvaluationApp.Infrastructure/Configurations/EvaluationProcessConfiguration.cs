using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    public class EvaluationProcessConfiguration : IEntityTypeConfiguration<EvaluationProcess>
    {
        public void Configure(EntityTypeBuilder<EvaluationProcess> builder)
        {
            builder.HasKey(e => e.EvaluationId);

            builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.Owner)
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(e => e.Consultant)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(e => e.Status)
             .IsRequired()
             .HasMaxLength(50);
        }
    }
}
