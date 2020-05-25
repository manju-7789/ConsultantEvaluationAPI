using ConsultantEvaluatonApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantEvaluationApp.Infrastructure.Configurations
{
    class TechSubAreaConfiguration : IEntityTypeConfiguration<TechSubArea>
    {
        public void Configure(EntityTypeBuilder<TechSubArea> builder)
        {
            builder.HasKey(e => e.SubTechId);

            builder.HasIndex(e => e.TechId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Tech)
                .WithMany(p => p.TechSubArea)
                .HasForeignKey(d => d.TechId);
        }
    }
}
