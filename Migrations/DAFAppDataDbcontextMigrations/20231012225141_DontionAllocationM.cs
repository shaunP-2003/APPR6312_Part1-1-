using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class DontionAllocationM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "DonationAllocationMonetary",
                columns: table => new
                {
                    AllocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoneyDonationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationAllocationMonetary", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_DonationAllocationMonetary_Disasters_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disasters",
                        principalColumn: "DisasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationAllocationMonetary_MonetaryDonations_MoneyDonationId",
                        column: x => x.MoneyDonationId,
                        principalTable: "MonetaryDonations",
                        principalColumn: "MoneyDonationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationAllocationMonetary_DisasterId",
                table: "DonationAllocationMonetary",
                column: "DisasterId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationAllocationMonetary_MoneyDonationId",
                table: "DonationAllocationMonetary",
                column: "MoneyDonationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationAllocationMonetary");

   
        }
    }
}
