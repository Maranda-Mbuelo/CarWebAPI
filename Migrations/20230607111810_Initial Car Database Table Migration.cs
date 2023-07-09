using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCarDatabaseTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarYearMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarTransmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarEngineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarNoOfGears = table.Column<int>(type: "int", nullable: false),
                    CarHorsePower = table.Column<int>(type: "int", nullable: false),
                    CarTorque = table.Column<int>(type: "int", nullable: false),
                    CarKilowatts = table.Column<int>(type: "int", nullable: false),
                    CarEngineSize = table.Column<int>(type: "int", nullable: false),
                    CarNoOfSeats = table.Column<int>(type: "int", nullable: false),
                    CarFuelConsuption = table.Column<int>(type: "int", nullable: false),
                    CarFuelTankSize = table.Column<int>(type: "int", nullable: false),
                    CarAcceleration = table.Column<int>(type: "int", nullable: false),
                    CarPrice = table.Column<int>(type: "int", nullable: false),
                    // ...
                    CarFeaturedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    // ...

                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
