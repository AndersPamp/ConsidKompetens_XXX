using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations
{
    public partial class secundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AboutMe = table.Column<string>(nullable: true),
                    ProfileImageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeUsers_ImageModel_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "ImageModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IconId = table.Column<Guid>(nullable: true),
                    EmployeeUserModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceModel_EmployeeUsers_EmployeeUserModelId",
                        column: x => x.EmployeeUserModelId,
                        principalTable: "EmployeeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetenceModel_ImageModel_IconId",
                        column: x => x.IconId,
                        principalTable: "ImageModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModel_EmployeeUserModelId",
                table: "CompetenceModel",
                column: "EmployeeUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModel_IconId",
                table: "CompetenceModel",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUsers_ProfileImageId",
                table: "EmployeeUsers",
                column: "ProfileImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenceModel");

            migrationBuilder.DropTable(
                name: "EmployeeUsers");

            migrationBuilder.DropTable(
                name: "ImageModel");
        }
    }
}
