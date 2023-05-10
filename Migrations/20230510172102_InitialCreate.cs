using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace world_of_data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WoWClasses",
                columns: table => new
                {
                    WoWClassID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    className = table.Column<string>(type: "TEXT", nullable: false),
                    classSpec = table.Column<string>(type: "TEXT", nullable: false),
                    classArmor = table.Column<string>(type: "TEXT", nullable: false),
                    classRole = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoWClasses", x => x.WoWClassID);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    charName = table.Column<string>(type: "TEXT", nullable: false),
                    Realm = table.Column<string>(type: "TEXT", nullable: false),
                    iLVL = table.Column<int>(type: "INTEGER", nullable: false),
                    Arena2v2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Arena3v3 = table.Column<int>(type: "INTEGER", nullable: false),
                    MythicScore = table.Column<int>(type: "INTEGER", nullable: false),
                    WoWClassID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Character_WoWClasses_WoWClassID",
                        column: x => x.WoWClassID,
                        principalTable: "WoWClasses",
                        principalColumn: "WoWClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_WoWClassID",
                table: "Character",
                column: "WoWClassID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "WoWClasses");
        }
    }
}
