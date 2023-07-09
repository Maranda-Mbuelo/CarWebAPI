using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCarFeaturedImageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CarFeaturedImage",
                table: "Cars",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarFeaturedImage",
                table: "Cars");
        }
    }
}
