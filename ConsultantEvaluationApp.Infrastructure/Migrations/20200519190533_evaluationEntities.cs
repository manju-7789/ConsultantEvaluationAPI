using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultantEvaluationApp.Infrastructure.Migrations
{
    public partial class evaluationEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationProcesses",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Owner = table.Column<string>(maxLength: 50, nullable: false),
                    Consultant = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    StatusType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationProcesses", x => x.EvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "TechnologyAreas",
                columns: table => new
                {
                    TechId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyAreas", x => x.TechId);
                });

            migrationBuilder.CreateTable(
                name: "Evaluators",
                columns: table => new
                {
                    EvaluatorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    EvaluatorEmail = table.Column<string>(maxLength: 150, nullable: false),
                    IsSubmitted = table.Column<bool>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluators", x => x.EvaluatorId);
                    table.ForeignKey(
                        name: "FK_Evaluators_EvaluationProcesses_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "EvaluationProcesses",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<int>(nullable: false),
                    TechId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationTechnologies_EvaluationProcesses_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "EvaluationProcesses",
                        principalColumn: "EvaluationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvaluationTechnologies_TechnologyAreas_TechId",
                        column: x => x.TechId,
                        principalTable: "TechnologyAreas",
                        principalColumn: "TechId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechSubAreas",
                columns: table => new
                {
                    SubTechId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TechId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechSubAreas", x => x.SubTechId);
                    table.ForeignKey(
                        name: "FK_TechSubAreas_TechnologyAreas_TechId",
                        column: x => x.TechId,
                        principalTable: "TechnologyAreas",
                        principalColumn: "TechId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechAreaRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendationNotes = table.Column<string>(maxLength: 150, nullable: true),
                    EvaluatorId = table.Column<int>(nullable: false),
                    TechId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechAreaRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechAreaRecommendations_Evaluators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Evaluators",
                        principalColumn: "EvaluatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechAreaRecommendations_TechnologyAreas_TechId",
                        column: x => x.TechId,
                        principalTable: "TechnologyAreas",
                        principalColumn: "TechId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubAreaFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackNotes = table.Column<string>(maxLength: 150, nullable: true),
                    EvaluatorId = table.Column<int>(nullable: false),
                    SubTechId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAreaFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubAreaFeedbacks_Evaluators_EvaluatorId",
                        column: x => x.EvaluatorId,
                        principalTable: "Evaluators",
                        principalColumn: "EvaluatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubAreaFeedbacks_TechSubAreas_SubTechId",
                        column: x => x.SubTechId,
                        principalTable: "TechSubAreas",
                        principalColumn: "SubTechId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationTechnologies_EvaluationId",
                table: "EvaluationTechnologies",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationTechnologies_TechId",
                table: "EvaluationTechnologies",
                column: "TechId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluators_EvaluationId",
                table: "Evaluators",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAreaFeedbacks_EvaluatorId",
                table: "SubAreaFeedbacks",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAreaFeedbacks_SubTechId",
                table: "SubAreaFeedbacks",
                column: "SubTechId");

            migrationBuilder.CreateIndex(
                name: "IX_TechAreaRecommendations_EvaluatorId",
                table: "TechAreaRecommendations",
                column: "EvaluatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TechAreaRecommendations_TechId",
                table: "TechAreaRecommendations",
                column: "TechId");

            migrationBuilder.CreateIndex(
                name: "IX_TechSubAreas_TechId",
                table: "TechSubAreas",
                column: "TechId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationTechnologies");

            migrationBuilder.DropTable(
                name: "SubAreaFeedbacks");

            migrationBuilder.DropTable(
                name: "TechAreaRecommendations");

            migrationBuilder.DropTable(
                name: "TechSubAreas");

            migrationBuilder.DropTable(
                name: "Evaluators");

            migrationBuilder.DropTable(
                name: "TechnologyAreas");

            migrationBuilder.DropTable(
                name: "EvaluationProcesses");
        }
    }
}
