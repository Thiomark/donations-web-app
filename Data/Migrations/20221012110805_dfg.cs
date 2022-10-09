using Microsoft.EntityFrameworkCore.Migrations;

namespace Donation.Data.Migrations
{
    public partial class dfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "AllocateMoney");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RemainingAmount",
                table: "AllocateMoney",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
