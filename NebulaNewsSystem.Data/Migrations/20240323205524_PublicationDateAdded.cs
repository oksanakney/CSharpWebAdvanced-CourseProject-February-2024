using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    public partial class PublicationDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 23, 20, 55, 24, 143, DateTimeKind.Utc).AddTicks(8836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 20, 13, 35, 21, 388, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 23, 20, 55, 24, 144, DateTimeKind.Utc).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 23, 20, 55, 24, 144, DateTimeKind.Utc).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 23, 20, 55, 24, 144, DateTimeKind.Utc).AddTicks(988));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 20, 13, 35, 21, 388, DateTimeKind.Utc).AddTicks(5123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 23, 20, 55, 24, 143, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 20, 13, 35, 21, 388, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 20, 13, 35, 21, 388, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 20, 13, 35, 21, 388, DateTimeKind.Utc).AddTicks(6645));
        }
    }
}
