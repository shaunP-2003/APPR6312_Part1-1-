using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
            name: "goodsDonationId",
            table: "Disasters",
            nullable: false,
            defaultValue: Guid.NewGuid());

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

        }
    }
}
