using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddAllo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AidType",
                table: "Disasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
            name: "DisasterId",
            table: "goodsDonations",
            type: "uniqueidentifier",
            nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_goodsDonations_DisasterId",
                table: "goodsDonations",
                column: "DisasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsDonations_Disasters_DisasterId",
                table: "goodsDonations",
                column: "DisasterId",
                principalTable: "Disasters",
                principalColumn: "DisasterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AidType",
                table: "Disasters");

            migrationBuilder.DropForeignKey(
            name: "FK_goodsDonations_Disasters_DisasterId",
            table: "goodsDonations");

            migrationBuilder.DropIndex(
                name: "IX_goodsDonations_DisasterId",
                table: "goodsDonations");

            migrationBuilder.DropColumn(
                name: "DisasterId",
                table: "goodsDonations");
        }
    }
}
