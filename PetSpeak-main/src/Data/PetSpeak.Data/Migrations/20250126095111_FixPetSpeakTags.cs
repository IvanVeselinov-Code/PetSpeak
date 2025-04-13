using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetSpeak.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixPetSpeakTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSpeakTag_Communities_PetSpeakCommunityId",
                table: "PetSpeakTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PetSpeakTag_PetSpeakThread_PetSpeakThreadId",
                table: "PetSpeakTag");

            migrationBuilder.DropIndex(
                name: "IX_PetSpeakTag_PetSpeakCommunityId",
                table: "PetSpeakTag");

            migrationBuilder.DropIndex(
                name: "IX_PetSpeakTag_PetSpeakThreadId",
                table: "PetSpeakTag");

            migrationBuilder.DropColumn(
                name: "PetSpeakCommunityId",
                table: "PetSpeakTag");

            migrationBuilder.DropColumn(
                name: "PetSpeakThreadId",
                table: "PetSpeakTag");

            migrationBuilder.CreateTable(
                name: "PetSpeakCommunityPetSpeakTag",
                columns: table => new
                {
                    PetSpeakCommunityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetSpeakCommunityPetSpeakTag", x => new { x.PetSpeakCommunityId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PetSpeakCommunityPetSpeakTag_Communities_PetSpeakCommunityId",
                        column: x => x.PetSpeakCommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetSpeakCommunityPetSpeakTag_PetSpeakTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PetSpeakTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetSpeakTagPetSpeakThread",
                columns: table => new
                {
                    PetSpeakThreadId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetSpeakTagPetSpeakThread", x => new { x.PetSpeakThreadId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PetSpeakTagPetSpeakThread_PetSpeakTag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PetSpeakTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetSpeakTagPetSpeakThread_PetSpeakThread_PetSpeakThreadId",
                        column: x => x.PetSpeakThreadId,
                        principalTable: "PetSpeakThread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakCommunityPetSpeakTag_TagsId",
                table: "PetSpeakCommunityPetSpeakTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTagPetSpeakThread_TagsId",
                table: "PetSpeakTagPetSpeakThread",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetSpeakCommunityPetSpeakTag");

            migrationBuilder.DropTable(
                name: "PetSpeakTagPetSpeakThread");

            migrationBuilder.AddColumn<string>(
                name: "PetSpeakCommunityId",
                table: "PetSpeakTag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetSpeakThreadId",
                table: "PetSpeakTag",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_PetSpeakCommunityId",
                table: "PetSpeakTag",
                column: "PetSpeakCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_PetSpeakThreadId",
                table: "PetSpeakTag",
                column: "PetSpeakThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSpeakTag_Communities_PetSpeakCommunityId",
                table: "PetSpeakTag",
                column: "PetSpeakCommunityId",
                principalTable: "Communities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSpeakTag_PetSpeakThread_PetSpeakThreadId",
                table: "PetSpeakTag",
                column: "PetSpeakThreadId",
                principalTable: "PetSpeakThread",
                principalColumn: "Id");
        }
    }
}
