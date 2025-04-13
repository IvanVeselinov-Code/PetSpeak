using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetSpeak.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenericMetadataConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_CreatedById",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_DeletedById",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_UpdatedById",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_Threads_Categories_CategoryId",
                table: "Threads");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadComment_Threads_ThreadId",
                table: "UserThreadComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Threads",
                table: "Threads");

            migrationBuilder.RenameTable(
                name: "Threads",
                newName: "PetSpeakThread");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "PetSpeakThread",
                newName: "CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_UpdatedById",
                table: "PetSpeakThread",
                newName: "IX_PetSpeakThread_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_DeletedById",
                table: "PetSpeakThread",
                newName: "IX_PetSpeakThread_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CreatedById",
                table: "PetSpeakThread",
                newName: "IX_PetSpeakThread_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Threads_CategoryId",
                table: "PetSpeakThread",
                newName: "IX_PetSpeakThread_CommunityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetSpeakThread",
                table: "PetSpeakThread",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailPhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BannerPhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Communities_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Communities_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Communities_Attachments_BannerPhotoId",
                        column: x => x.BannerPhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Communities_Attachments_ThumbnailPhotoId",
                        column: x => x.ThumbnailPhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PetSpeakTag",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetSpeakCommunityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PetSpeakThreadId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetSpeakTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetSpeakTag_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetSpeakTag_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetSpeakTag_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetSpeakTag_Communities_PetSpeakCommunityId",
                        column: x => x.PetSpeakCommunityId,
                        principalTable: "Communities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PetSpeakTag_PetSpeakThread_PetSpeakThreadId",
                        column: x => x.PetSpeakThreadId,
                        principalTable: "PetSpeakThread",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_BannerPhotoId",
                table: "Communities",
                column: "BannerPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_CreatedById",
                table: "Communities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_DeletedById",
                table: "Communities",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_ThumbnailPhotoId",
                table: "Communities",
                column: "ThumbnailPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_UpdatedById",
                table: "Communities",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_CreatedById",
                table: "PetSpeakTag",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_DeletedById",
                table: "PetSpeakTag",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_PetSpeakCommunityId",
                table: "PetSpeakTag",
                column: "PetSpeakCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_PetSpeakThreadId",
                table: "PetSpeakTag",
                column: "PetSpeakThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_PetSpeakTag_UpdatedById",
                table: "PetSpeakTag",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSpeakThread_AspNetUsers_CreatedById",
                table: "PetSpeakThread",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSpeakThread_AspNetUsers_DeletedById",
                table: "PetSpeakThread",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSpeakThread_AspNetUsers_UpdatedById",
                table: "PetSpeakThread",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetSpeakThread_Communities_CommunityId",
                table: "PetSpeakThread",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadComment_PetSpeakThread_ThreadId",
                table: "UserThreadComment",
                column: "ThreadId",
                principalTable: "PetSpeakThread",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadReaction_PetSpeakThread_ThreadId",
                table: "UserThreadReaction",
                column: "ThreadId",
                principalTable: "PetSpeakThread",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetSpeakThread_AspNetUsers_CreatedById",
                table: "PetSpeakThread");

            migrationBuilder.DropForeignKey(
                name: "FK_PetSpeakThread_AspNetUsers_DeletedById",
                table: "PetSpeakThread");

            migrationBuilder.DropForeignKey(
                name: "FK_PetSpeakThread_AspNetUsers_UpdatedById",
                table: "PetSpeakThread");

            migrationBuilder.DropForeignKey(
                name: "FK_PetSpeakThread_Communities_CommunityId",
                table: "PetSpeakThread");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadComment_PetSpeakThread_ThreadId",
                table: "UserThreadComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserThreadReaction_PetSpeakThread_ThreadId",
                table: "UserThreadReaction");

            migrationBuilder.DropTable(
                name: "PetSpeakTag");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetSpeakThread",
                table: "PetSpeakThread");

            migrationBuilder.RenameTable(
                name: "PetSpeakThread",
                newName: "Threads");

            migrationBuilder.RenameColumn(
                name: "CommunityId",
                table: "Threads",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PetSpeakThread_UpdatedById",
                table: "Threads",
                newName: "IX_Threads_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PetSpeakThread_DeletedById",
                table: "Threads",
                newName: "IX_Threads_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_PetSpeakThread_CreatedById",
                table: "Threads",
                newName: "IX_Threads_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PetSpeakThread_CommunityId",
                table: "Threads",
                newName: "IX_Threads_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Threads",
                table: "Threads",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoverPhotoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories_Attachments_CoverPhotoId",
                        column: x => x.CoverPhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CoverPhotoId",
                table: "Categories",
                column: "CoverPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedById",
                table: "Categories",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_CreatedById",
                table: "Threads",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_DeletedById",
                table: "Threads",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_UpdatedById",
                table: "Threads",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_Categories_CategoryId",
                table: "Threads",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadComment_Threads_ThreadId",
                table: "UserThreadComment",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserThreadReaction_Threads_ThreadId",
                table: "UserThreadReaction",
                column: "ThreadId",
                principalTable: "Threads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
