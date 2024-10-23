using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationSystem.Data.Migrations
{
    public partial class RankingDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Ranking",
                table: "Reservation",
                type: "float",
                nullable: false,
                defaultValue: 1.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ranking",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 1.0);
        }
    }
}
