using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbstractionOrganizer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessModifier = table.Column<int>(type: "int", nullable: false),
                    ClassModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassHeaders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ClassHeaders",
                columns: new[] { "Id", "AccessModifier", "ClassModifier", "Name" },
                values: new object[,]
                {
                    { 1, 0, 0, "class1" },
                    { 2, 2, 0, "class2" },
                    { 3, 2, 1, "class3" },
                    { 4, 1, 2, "class4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassHeaders");
        }
    }
}
