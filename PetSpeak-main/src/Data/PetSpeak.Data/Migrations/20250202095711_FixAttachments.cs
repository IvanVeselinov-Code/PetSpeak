using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetSpeak.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAttachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Comments_CommentId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CommentId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Attachments");

            migrationBuilder.CreateTable(
                name: "AttachmentComment",
                columns: table => new
                {
                    AttachmentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentComment", x => new { x.AttachmentsId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_AttachmentComment_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentComment_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentPetSpeakThread",
                columns: table => new
                {
                    AttachmentsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PetSpeakThreadId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentPetSpeakThread", x => new { x.AttachmentsId, x.PetSpeakThreadId });
                    table.ForeignKey(
                        name: "FK_AttachmentPetSpeakThread_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentPetSpeakThread_PetSpeakThread_PetSpeakThreadId",
                        column: x => x.PetSpeakThreadId,
                        principalTable: "PetSpeakThread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentComment_CommentId",
                table: "AttachmentComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentPetSpeakThread_PetSpeakThreadId",
                table: "AttachmentPetSpeakThread",
                column: "PetSpeakThreadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentComment");

            migrationBuilder.DropTable(
                name: "AttachmentPetSpeakThread");

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CommentId",
                table: "Attachments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Comments_CommentId",
                table: "Attachments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
