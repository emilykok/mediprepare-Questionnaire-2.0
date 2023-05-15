using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediPrepareQuestionair.Migrations
{
    /// <inheritdoc />
    public partial class InitialD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    FormName = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    SectionName = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    DependsOnSectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FormId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sections_Sections_DependsOnSectionId",
                        column: x => x.DependsOnSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferenceFormId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ReferencePatientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerForms_Forms_ReferenceFormId",
                        column: x => x.ReferenceFormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerForms_Patients_ReferencePatientId",
                        column: x => x.ReferencePatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    SectionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferenceSectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AnswerFormId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AnswerFormId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerSections_AnswerForms_AnswerFormId",
                        column: x => x.AnswerFormId,
                        principalTable: "AnswerForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerSections_AnswerForms_AnswerFormId1",
                        column: x => x.AnswerFormId1,
                        principalTable: "AnswerForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerSections_Sections_ReferenceSectionId",
                        column: x => x.ReferenceSectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionEventInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventName = table.Column<string>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionId = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionVersion = table.Column<string>(type: "TEXT", nullable: false),
                    AnswerFormId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionEventInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionEventInputs_AnswerForms_AnswerFormId",
                        column: x => x.AnswerFormId,
                        principalTable: "AnswerForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Option = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => new { x.QuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReferenceQuestionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AnswerSectionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AnswerSectionId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerQuestions_AnswerSections_AnswerSectionId",
                        column: x => x.AnswerSectionId,
                        principalTable: "AnswerSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerQuestions_AnswerSections_AnswerSectionId1",
                        column: x => x.AnswerSectionId1,
                        principalTable: "AnswerSections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerQuestions_Questions_ReferenceQuestionId",
                        column: x => x.ReferenceQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswerValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AnswerQuestionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerValue", x => new { x.AnswerQuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_QuestionAnswerValue_AnswerQuestions_AnswerQuestionId",
                        column: x => x.AnswerQuestionId,
                        principalTable: "AnswerQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerForms_ReferenceFormId",
                table: "AnswerForms",
                column: "ReferenceFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerForms_ReferencePatientId",
                table: "AnswerForms",
                column: "ReferencePatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestions_AnswerSectionId",
                table: "AnswerQuestions",
                column: "AnswerSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestions_AnswerSectionId1",
                table: "AnswerQuestions",
                column: "AnswerSectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestions_ReferenceQuestionId",
                table: "AnswerQuestions",
                column: "ReferenceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_AnswerFormId",
                table: "AnswerSections",
                column: "AnswerFormId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_AnswerFormId1",
                table: "AnswerSections",
                column: "AnswerFormId1");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSections_ReferenceSectionId",
                table: "AnswerSections",
                column: "ReferenceSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionEventInputs_AnswerFormId",
                table: "QuestionEventInputs",
                column: "AnswerFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SectionId",
                table: "Questions",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DependsOnSectionId",
                table: "Sections",
                column: "DependsOnSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_FormId",
                table: "Sections",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnswerValue");

            migrationBuilder.DropTable(
                name: "QuestionEventInputs");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "AnswerQuestions");

            migrationBuilder.DropTable(
                name: "AnswerSections");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AnswerForms");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
