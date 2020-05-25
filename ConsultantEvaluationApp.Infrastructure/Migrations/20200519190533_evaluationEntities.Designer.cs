﻿// <auto-generated />
using System;
using ConsultantEvaluationApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsultantEvaluationApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200519190533_evaluationEntities")]
    partial class evaluationEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Consultant")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("StatusType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("EvaluationId");

                    b.ToTable("EvaluationProcesses");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.EvaluationTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<int>("TechId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationId");

                    b.HasIndex("TechId");

                    b.ToTable("EvaluationTechnologies");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.Evaluator", b =>
                {
                    b.Property<int>("EvaluatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvaluationId")
                        .HasColumnType("int");

                    b.Property<string>("EvaluatorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("IsSubmitted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvaluatorId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("Evaluators");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.SubAreaFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EvaluatorId")
                        .HasColumnType("int");

                    b.Property<string>("FeedbackNotes")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("SubTechId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatorId");

                    b.HasIndex("SubTechId");

                    b.ToTable("SubAreaFeedbacks");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.TechAreaRecommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EvaluatorId")
                        .HasColumnType("int");

                    b.Property<string>("RecommendationNotes")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("TechId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatorId");

                    b.HasIndex("TechId");

                    b.ToTable("TechAreaRecommendations");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.TechSubArea", b =>
                {
                    b.Property<int>("SubTechId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TechId")
                        .HasColumnType("int");

                    b.HasKey("SubTechId");

                    b.HasIndex("TechId");

                    b.ToTable("TechSubAreas");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.TechnologyArea", b =>
                {
                    b.Property<int>("TechId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TechId");

                    b.ToTable("TechnologyAreas");
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.EvaluationTechnology", b =>
                {
                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess", "Evaluation")
                        .WithMany("EvaluationTechnologies")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.TechnologyArea", "TechnologyArea")
                        .WithMany("EvaluationTechnology")
                        .HasForeignKey("TechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.Evaluator", b =>
                {
                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.EvaluationProcess", "Evaluation")
                        .WithMany("Evaluators")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.SubAreaFeedback", b =>
                {
                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.Evaluator", "Evaluator")
                        .WithMany("SubAreaFeedback")
                        .HasForeignKey("EvaluatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.TechSubArea", "SubTech")
                        .WithMany("SubAreaFeedback")
                        .HasForeignKey("SubTechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.TechAreaRecommendation", b =>
                {
                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.Evaluator", "Evaluator")
                        .WithMany("TechAreaRecommendation")
                        .HasForeignKey("EvaluatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.TechnologyArea", "Tech")
                        .WithMany("TechAreaRecommendation")
                        .HasForeignKey("TechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsultantEvaluatonApp.Domain.Entities.TechSubArea", b =>
                {
                    b.HasOne("ConsultantEvaluatonApp.Domain.Entities.TechnologyArea", "Tech")
                        .WithMany("TechSubArea")
                        .HasForeignKey("TechId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
