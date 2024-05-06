using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddDonoAllocation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisasterGoodsAllocationId",
                table: "DonationsAllo",
                newName: "AllocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AllocationId",
                table: "DonationsAllo",
                newName: "DisasterGoodsAllocationId");
        }
    }
}
