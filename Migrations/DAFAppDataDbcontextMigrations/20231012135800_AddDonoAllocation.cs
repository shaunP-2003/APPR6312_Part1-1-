using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddDonoAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DonationsAllo",
                columns: table => new
                {
                    DisasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsDonationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    goodsCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationsAllo", x => new { x.AllocationId, });
                    table.ForeignKey(
                        name: "FK_DonationsAllo_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationsAllo_goodsDonations_GoodsDonationId",
                        column: x => x.GoodsDonationId,
                        principalTable: "goodsDonations",
                        principalColumn: "goodDonationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationsAllo_GoodsDonationId",
                table: "DonationsAllo",
                column: "GoodsDonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationsAllo");

            migrationBuilder.AddColumn<Guid>(
                name: "GoodsDonationId",
                table: "Disasters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Disasters_GoodsDonationId",
                table: "Disasters",
                column: "GoodsDonationId");

            migrationBuilder.DropForeignKey(
                name: "FK_Disasters_goodsDonations_GoodsDonationId",
                table: "Disasters");

            migrationBuilder.DropIndex(
                name: "IX_Disasters_GoodsDonationId",
                table: "Disasters");

            migrationBuilder.DropColumn(
                name: "GoodsDonationId",
                table: "Disasters");

        }
    }
}
