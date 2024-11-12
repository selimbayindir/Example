using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Istanbul" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "District",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1, 1, "Sancaktepe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "District",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "City",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
