using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbstractionOrganizer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class variableTypeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "VariableModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "VariableModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Int");

            migrationBuilder.UpdateData(
                table: "VariableModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "String");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "VariableModels");
        }
    }
}
