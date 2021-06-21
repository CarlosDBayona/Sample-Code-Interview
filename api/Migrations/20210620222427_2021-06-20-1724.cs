using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class _202106201724 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Companies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentificationTypeId",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IdentificationTypeId",
                table: "Companies",
                column: "IdentificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_IdentificationTypes_IdentificationTypeId",
                table: "Companies",
                column: "IdentificationTypeId",
                principalTable: "IdentificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_IdentificationTypes_IdentificationTypeId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_IdentificationTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IdentificationTypeId",
                table: "Companies");
        }
    }
}
