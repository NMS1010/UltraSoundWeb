using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraSoundWeb.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicDescriptionResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicConclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicRecommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializeds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UltraSoundSamples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultDiagnostic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultConclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultRecommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UltraSoundSamples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializedId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializeds_SpecializedId",
                        column: x => x.SpecializedId,
                        principalTable: "Specializeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UltraSoundResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltraSoundSampleId = table.Column<long>(type: "bigint", nullable: true),
                    DoctorUltraSoundId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorSpecifyId = table.Column<long>(type: "bigint", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UltraSoundResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UltraSoundResults_Doctors_DoctorSpecifyId",
                        column: x => x.DoctorSpecifyId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UltraSoundResults_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UltraSoundResults_UltraSoundSamples_UltraSoundSampleId",
                        column: x => x.UltraSoundSampleId,
                        principalTable: "UltraSoundSamples",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltraSoundResultId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultImages_UltraSoundResults_UltraSoundResultId",
                        column: x => x.UltraSoundResultId,
                        principalTable: "UltraSoundResults",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Specializeds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Bác sĩ siêu âm" },
                    { 2L, "Bác sĩ chỉ định" },
                    { 3L, "Bác sĩ kê toa" },
                    { 4L, "Bác sĩ quản lý" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { 1L, "i2yBMU+FxDo=", 1, "admin" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "SpecializedId", "UserId" },
                values: new object[] { 1L, "Doctor Admin", 4L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializedId",
                table: "Doctors",
                column: "SpecializedId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResultImages_UltraSoundResultId",
                table: "ResultImages",
                column: "UltraSoundResultId");

            migrationBuilder.CreateIndex(
                name: "IX_UltraSoundResults_DoctorSpecifyId",
                table: "UltraSoundResults",
                column: "DoctorSpecifyId");

            migrationBuilder.CreateIndex(
                name: "IX_UltraSoundResults_PatientId",
                table: "UltraSoundResults",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UltraSoundResults_UltraSoundSampleId",
                table: "UltraSoundResults",
                column: "UltraSoundSampleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "ResultImages");

            migrationBuilder.DropTable(
                name: "UltraSoundResults");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "UltraSoundSamples");

            migrationBuilder.DropTable(
                name: "Specializeds");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
