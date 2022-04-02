using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonRegisteration.Migrations
{
    public partial class syncdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Personality_PersonalityId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonalityId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonalityId",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalityId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
