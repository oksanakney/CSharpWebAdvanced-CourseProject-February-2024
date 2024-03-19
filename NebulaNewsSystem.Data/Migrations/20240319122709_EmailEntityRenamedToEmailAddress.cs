using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    public partial class EmailEntityRenamedToEmailAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Authors",
                newName: "EmailAddress");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 19, 12, 27, 8, 541, DateTimeKind.Utc).AddTicks(4062),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(8714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 19, 12, 27, 8, 540, DateTimeKind.Utc).AddTicks(9708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 19, 12, 27, 8, 541, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 19, 12, 27, 8, 541, DateTimeKind.Utc).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "CommentId",
                keyValue: new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                column: "CreationDate",
                value: new DateTime(2024, 3, 19, 12, 27, 8, 541, DateTimeKind.Utc).AddTicks(5136));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Authors",
                newName: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(8714),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 19, 12, 27, 8, 541, DateTimeKind.Utc).AddTicks(4062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 18, 19, 44, 48, 285, DateTimeKind.Utc).AddTicks(1941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 19, 12, 27, 8, 540, DateTimeKind.Utc).AddTicks(9708));

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
        }
    }
}
