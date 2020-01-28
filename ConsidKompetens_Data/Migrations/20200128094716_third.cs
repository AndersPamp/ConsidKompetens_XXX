using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModel_EmployeeUsers_EmployeeUserModelId",
                table: "CompetenceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModel_ImageModel_IconId",
                table: "CompetenceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceModel",
                table: "CompetenceModel");

            migrationBuilder.RenameTable(
                name: "CompetenceModel",
                newName: "CompetenceModels");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceModel_IconId",
                table: "CompetenceModels",
                newName: "IX_CompetenceModels_IconId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceModel_EmployeeUserModelId",
                table: "CompetenceModels",
                newName: "IX_CompetenceModels_EmployeeUserModelId");

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeModelId",
                table: "EmployeeUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceModels",
                table: "CompetenceModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RegionModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<long>(nullable: false),
                    TelephoneNumber = table.Column<long>(nullable: false),
                    RegionModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeModels_RegionModels_RegionModelId",
                        column: x => x.RegionModelId,
                        principalTable: "RegionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUsers_OfficeModelId",
                table: "EmployeeUsers",
                column: "OfficeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeModels_RegionModelId",
                table: "OfficeModels",
                column: "RegionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModels_EmployeeUsers_EmployeeUserModelId",
                table: "CompetenceModels",
                column: "EmployeeUserModelId",
                principalTable: "EmployeeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModels_ImageModel_IconId",
                table: "CompetenceModels",
                column: "IconId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeUsers_OfficeModels_OfficeModelId",
                table: "EmployeeUsers",
                column: "OfficeModelId",
                principalTable: "OfficeModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModels_EmployeeUsers_EmployeeUserModelId",
                table: "CompetenceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModels_ImageModel_IconId",
                table: "CompetenceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeUsers_OfficeModels_OfficeModelId",
                table: "EmployeeUsers");

            migrationBuilder.DropTable(
                name: "OfficeModels");

            migrationBuilder.DropTable(
                name: "RegionModels");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeUsers_OfficeModelId",
                table: "EmployeeUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceModels",
                table: "CompetenceModels");

            migrationBuilder.DropColumn(
                name: "OfficeModelId",
                table: "EmployeeUsers");

            migrationBuilder.RenameTable(
                name: "CompetenceModels",
                newName: "CompetenceModel");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceModels_IconId",
                table: "CompetenceModel",
                newName: "IX_CompetenceModel_IconId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceModels_EmployeeUserModelId",
                table: "CompetenceModel",
                newName: "IX_CompetenceModel_EmployeeUserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceModel",
                table: "CompetenceModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModel_EmployeeUsers_EmployeeUserModelId",
                table: "CompetenceModel",
                column: "EmployeeUserModelId",
                principalTable: "EmployeeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModel_ImageModel_IconId",
                table: "CompetenceModel",
                column: "IconId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
