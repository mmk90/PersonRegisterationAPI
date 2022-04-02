using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonRegisteration.Migrations
{
    public partial class addPersonality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalityId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Personality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personality", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonalityId",
                table: "People",
                column: "PersonalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Personality_PersonalityId",
                table: "People",
                column: "PersonalityId",
                principalTable: "Personality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Personality_PersonalityId",
                table: "People");

            migrationBuilder.DropTable(
                name: "Personality");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonalityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonalityId",
                table: "People");
        }
    }
}
