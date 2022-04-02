using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonRegisteration.Migrations
{
    public partial class syncdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonPersonality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PersonalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPersonality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPersonality_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPersonality_Personality_PersonalityId",
                        column: x => x.PersonalityId,
                        principalTable: "Personality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPersonality_PersonalityId",
                table: "PersonPersonality",
                column: "PersonalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPersonality_PersonId",
                table: "PersonPersonality",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPersonality");
        }
    }
}
