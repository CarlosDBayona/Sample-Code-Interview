using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class _2106142 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_IdentificationTypes_IdentificationTypeId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "IdentificationTypeId",
                table: "Companies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_IdentificationTypes_IdentificationTypeId",
                table: "Companies",
                column: "IdentificationTypeId",
                principalTable: "IdentificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_IdentificationTypes_IdentificationTypeId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "IdentificationTypeId",
                table: "Companies",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_IdentificationTypes_IdentificationTypeId",
                table: "Companies",
                column: "IdentificationTypeId",
                principalTable: "IdentificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
