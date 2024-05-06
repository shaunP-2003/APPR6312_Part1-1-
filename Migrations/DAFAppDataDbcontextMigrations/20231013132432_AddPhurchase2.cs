using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddPhurchase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_goodsDonations_goodDonationId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_goodDonationId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "goodDonationId",
                table: "Inventory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "goodDonationId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_goodDonationId",
                table: "Inventory",
                column: "goodDonationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_goodsDonations_goodDonationId",
                table: "Inventory",
                column: "goodDonationId",
                principalTable: "goodsDonations",
                principalColumn: "goodDonationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
