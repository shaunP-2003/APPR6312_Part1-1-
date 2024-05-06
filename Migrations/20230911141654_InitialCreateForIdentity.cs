using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateForIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disasters");

            migrationBuilder.DropTable(
                name: "goodsDonations");

            migrationBuilder.DropTable(
                name: "MonetaryDonations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disasters",
                columns: table => new
                {
                    DisasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisasterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisasterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disasters", x => x.DisasterId);
                });

            migrationBuilder.CreateTable(
                name: "goodsDonations",
                columns: table => new
                {
                    goodDonationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    goodsCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goodsDonations", x => x.goodDonationId);
                });

            migrationBuilder.CreateTable(
                name: "MonetaryDonations",
                columns: table => new
                {
                    MoneyDonationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonetaryDonations", x => x.MoneyDonationId);
                });
        }
    }
}
