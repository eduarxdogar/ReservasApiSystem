using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Data.Migrations
{
    public partial class ContactTypeNavigationProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Ranking",
                table: "Reservation",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 1.0);

            migrationBuilder.AddColumn<int>(
                name: "ContactTypeId1",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactTypeId1",
                table: "Contact",
                column: "ContactTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId1",
                table: "Contact",
                column: "ContactTypeId1",
                principalTable: "ContactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_ContactType_ContactTypeId1",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_ContactTypeId1",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactTypeId1",
                table: "Contact");

            migrationBuilder.AlterColumn<double>(
                name: "Ranking",
                table: "Reservation",
                type: "float",
                nullable: false,
                defaultValue: 1.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);
        }
    }
}
