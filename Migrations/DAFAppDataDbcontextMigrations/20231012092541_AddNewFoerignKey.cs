using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddNewFoerignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_goodsDonations_Disasters_DisasterId",
                table: "goodsDonations");

            migrationBuilder.DropIndex(
                name: "IX_goodsDonations_DisasterId",
                table: "goodsDonations");

            migrationBuilder.DropColumn(
                name: "DisasterId",
                table: "goodsDonations");

            migrationBuilder.AddColumn<Guid>(
                name: "GoodsDonationId",
                table: "Disasters",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Disasters_GoodsDonationId",
                table: "Disasters",
                column: "GoodsDonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disasters_goodsDonations_GoodsDonationId",
                table: "Disasters",
                column: "GoodsDonationId",
                principalTable: "goodsDonations",
                principalColumn: "goodDonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disasters_goodsDonations_GoodsDonationId",
                table: "Disasters");

            migrationBuilder.DropIndex(
                name: "IX_Disasters_GoodsDonationId",
                table: "Disasters");

            migrationBuilder.DropColumn(
                name: "GoodsDonationId",
                table: "Disasters");

            migrationBuilder.AddColumn<Guid>(
                name: "DisasterId",
                table: "goodsDonations",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_goodsDonations_DisasterId",
                table: "goodsDonations",
                column: "DisasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_goodsDonations_Disasters_DisasterId",
                table: "goodsDonations",
                column: "DisasterId",
                principalTable: "Disasters",
                principalColumn: "DisasterId");
        }
    }
}
