using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbstractionOrganizer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class methodTypeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReturnType",
                table: "MethodModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MethodModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReturnType",
                value: "void");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnType",
                table: "MethodModels");
        }
    }
}
