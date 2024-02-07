using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Friberg_Car_Rentals__Razor_Pages_3_.Migrations
{
    /// <inheritdoc />
    public partial class IsExpired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "Order");
        }
    }
}
