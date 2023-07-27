using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbstractionOrganizer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "VariableModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessModifier = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    ClassModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableModels_ClassHeaders_ClassModelId",
                        column: x => x.ClassModelId,
                        principalTable: "ClassHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "VariableModels",
                columns: new[] { "Id", "AccessModifier", "ClassModelId", "IsStatic", "Name" },
                values: new object[,]
                {
                    { 1, 0, 1, false, "testVar1" },
                    { 2, 1, 1, false, "testVar2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariableModels_ClassModelId",
                table: "VariableModels",
                column: "ClassModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariableModels");

            migrationBuilder.DropTable(
                name: "ClassHeaders");
        }
    }
}
