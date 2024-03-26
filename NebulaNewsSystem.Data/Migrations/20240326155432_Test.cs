using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_ReaderId",
                table: "Authors");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comment_AspNetUsers_CommenterId",
            //    table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "ReaderId",
                table: "Authors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    FeelsLikeTemperature = table.Column<double>(type: "float", nullable: false),
                    MinTemperature = table.Column<double>(type: "float", nullable: false),
                    MaxTemperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    WindSpeed = table.Column<double>(type: "float", nullable: false),
                    WindDirection = table.Column<double>(type: "float", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_ReaderId",
                table: "Authors",
                column: "ReaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comment_AspNetUsers_CommenterId",
            //    table: "Comment",
            //    column: "CommenterId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_AspNetUsers_ReaderId",
                table: "Authors");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comment_AspNetUsers_CommenterId",
            //    table: "Comment");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.AlterColumn<string>(
                name: "ReaderId",
                table: "Authors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_AspNetUsers_ReaderId",
                table: "Authors",
                column: "ReaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comment_AspNetUsers_CommenterId",
            //    table: "Comment",
            //    column: "CommenterId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");
        }
    }
}
