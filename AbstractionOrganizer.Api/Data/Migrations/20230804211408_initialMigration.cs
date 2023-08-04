using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbstractionOrganizer.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
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
                    AccessModifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassModifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentClassModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassHeaders_ClassHeaders_ParentClassModelId",
                        column: x => x.ParentClassModelId,
                        principalTable: "ClassHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VariableModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessModifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "AccessModifier", "ClassModifier", "Name", "ParentClassModelId" },
                values: new object[,]
                {
                    { 1, "Public", "Concrete", "class1", null },
                    { 2, "Protected", "Concrete", "class2", null },
                    { 3, "Protected", "Abstract", "class3", null },
                    { 4, "Private", "Static", "class4", null }
                });

            migrationBuilder.InsertData(
                table: "VariableModels",
                columns: new[] { "Id", "AccessModifier", "ClassModelId", "IsStatic", "Name" },
                values: new object[,]
                {
                    { 1, "Public", 1, false, "testVar1" },
                    { 2, "Private", 1, false, "testVar2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassHeaders_ParentClassModelId",
                table: "ClassHeaders",
                column: "ParentClassModelId");

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
