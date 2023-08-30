using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbstractionOrganizer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingAndEnumMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MethodModels",
                columns: new[] { "Id", "AccessModifier", "ClassModelId", "GetsInherited", "MethodModifier", "Name" },
                values: new object[] { 1, "Public", 1, true, "Static", "testMethod1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MethodModels",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
