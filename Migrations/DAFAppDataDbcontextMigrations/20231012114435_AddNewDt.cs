using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR6312_Part1_1_.Migrations.DAFAppDataDbcontextMigrations
{
    public partial class AddNewDt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
            name: "goodsDonationId",
            table: "Disasters",
            nullable: false,
            defaultValue: Guid.NewGuid());

                    migrationBuilder.CreateIndex(
            name: "IX_Disasters_GoodsDonationId",
            table: "Disasters",
            column: "goodsDonationId"
        );

            migrationBuilder.AddForeignKey(
                name: "FK_Disasters_goodsDonations_GoodsDonationId",
                table: "Disasters",
                column: "goodsDonationId",
                principalTable: "goodsDonations",
                principalColumn: "goodDonationId",
                onDelete: ReferentialAction.Restrict
            );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
    name: "IX_Disasters_GoodsDonationId",
    table: "Disasters"
);
            migrationBuilder.DropColumn(
    name: "goodsDonationId",
    table: "Disasters");


            migrationBuilder.DropForeignKey(
                name: "FK_Disasters_goodsDonations_GoodsDonationId",
                table: "Disasters"
            );
        }
    }
}
