using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    public partial class UpdatingAuthorAndCommentEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_CommenterId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "CommenterId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReaderId",
                table: "Authors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ReaderId",
                table: "Authors",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_ReaderId",
                table: "Authors",
                column: "ReaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_CommenterId",
                table: "Comment",
                column: "CommenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_ReaderId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_CommenterId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ReaderId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ReaderId",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "CommenterId",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_CommenterId",
                table: "Comment",
                column: "CommenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
