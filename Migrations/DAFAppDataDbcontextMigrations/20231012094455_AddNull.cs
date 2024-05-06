using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                    migrationBuilder.AlterColumn<Guid>(
            name: "goodsDonationId",
            table: "Disasters",
            type: "uniqueidentifier",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
