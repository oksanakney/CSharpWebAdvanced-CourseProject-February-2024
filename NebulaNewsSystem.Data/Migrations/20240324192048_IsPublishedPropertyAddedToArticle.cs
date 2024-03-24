using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    public partial class IsPublishedPropertyAddedToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 24, 19, 20, 48, 199, DateTimeKind.Utc).AddTicks(3107),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 24, 11, 15, 11, 203, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 19, 20, 48, 199, DateTimeKind.Utc).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 19, 20, 48, 199, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 19, 20, 48, 199, DateTimeKind.Utc).AddTicks(4800));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 24, 11, 15, 11, 203, DateTimeKind.Utc).AddTicks(6120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 24, 19, 20, 48, 199, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 11, 15, 11, 203, DateTimeKind.Utc).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 11, 15, 11, 203, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 24, 11, 15, 11, 203, DateTimeKind.Utc).AddTicks(7548));
        }
    }
}
