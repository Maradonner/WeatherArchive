using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherArchive.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MoscowTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    RelativeHumidity = table.Column<double>(type: "double precision", nullable: false),
                    Td = table.Column<double>(type: "double precision", nullable: false),
                    AtmosphericPressure = table.Column<int>(type: "integer", nullable: false),
                    WindDirection = table.Column<string>(type: "text", nullable: false),
                    WindVelocity = table.Column<double>(type: "double precision", nullable: false),
                    Cloudiness = table.Column<int>(type: "integer", nullable: true),
                    CloudinessLowerBoundary = table.Column<int>(type: "integer", nullable: true),
                    HorizontalVisibility = table.Column<int>(type: "integer", nullable: true),
                    WeatherPhenomena = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherRecords");
        }
    }
}
