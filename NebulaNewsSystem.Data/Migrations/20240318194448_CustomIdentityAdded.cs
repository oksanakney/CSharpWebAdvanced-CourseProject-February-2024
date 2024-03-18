using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    public partial class CustomIdentityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(8714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(1941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 18, 19, 44, 48, 286, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 18, 19, 44, 48, 286, DateTimeKind.Utc).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 18, 19, 44, 48, 286, DateTimeKind.Utc).AddTicks(336));

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ApplicationUserId",
                table: "Articles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_ApplicationUserId",
                table: "Articles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_ApplicationUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ApplicationUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(5452),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(78),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 14, 16, 32, 55, 753, DateTimeKind.Utc).AddTicks(6698));
        }
    }
}
