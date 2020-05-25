using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    class TechnologyConfiguration : IEntityTypeConfiguration<TechnologyArea>
    {
        public void Configure(EntityTypeBuilder<TechnologyArea> builder)
        {
            builder.HasKey(e => e.TechId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
