using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReasonTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ReasonDescription = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Reason",
                columns: new[] { "Id", "CreatedBy", "DateTime", "ReasonDescription", "ReasonTitle", "SortOrder" },
                values: new object[] { 1, 1, new DateTime(2021, 5, 23, 17, 9, 25, 342, DateTimeKind.Local).AddTicks(9999), "Having a better commute will really help with my gas costs and ware and tear on my car.", "Easy Commute", 2 });

            migrationBuilder.InsertData(
                table: "Reason",
                columns: new[] { "Id", "CreatedBy", "DateTime", "ReasonDescription", "ReasonTitle", "SortOrder" },
                values: new object[] { 2, 2, new DateTime(2021, 5, 23, 17, 9, 25, 343, DateTimeKind.Local).AddTicks(1166), "Working with a good stable company will be a nice change from the companies and contracts I've been envolved with in the past", "Stable company", 0 });

            migrationBuilder.InsertData(
                table: "Reason",
                columns: new[] { "Id", "CreatedBy", "DateTime", "ReasonDescription", "ReasonTitle", "SortOrder" },
                values: new object[] { 3, 4, new DateTime(2021, 5, 23, 17, 9, 25, 343, DateTimeKind.Local).AddTicks(1179), "The older I get the more important benifits matter to me.", "Good Benifits", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "ImageUrl", "JoinDate", "LastName" },
                values: new object[] { 1, "Robbert", "https://en.wikipedia.org/wiki/Robert_Smith_(musician)#/media/File:Robert_Smith_(musician)_crop.jpg", new DateTime(2019, 5, 23, 17, 9, 25, 340, DateTimeKind.Local).AddTicks(835), "Smith" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "ImageUrl", "JoinDate", "LastName" },
                values: new object[] { 2, "Sally", "https://en.wikipedia.org/wiki/Sally_Field#/media/File:Sally_Field_(11205)_(cropped).jpg", new DateTime(2020, 5, 23, 17, 9, 25, 341, DateTimeKind.Local).AddTicks(9305), "Field" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "ImageUrl", "JoinDate", "LastName" },
                values: new object[] { 3, "Peter", "https://en.wikipedia.org/wiki/Peter_Gabriel#/media/File:Peter_Gabriel_(3)_(cropped).jpg", new DateTime(2021, 3, 23, 17, 9, 25, 341, DateTimeKind.Local).AddTicks(9329), "Gaberial" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "ImageUrl", "JoinDate", "LastName" },
                values: new object[] { 4, "Genny", "https://en.wikipedia.org/wiki/Ginny_Weasley#/media/File:Ginny_Weasley_poster.jpg", new DateTime(2020, 2, 23, 17, 9, 25, 341, DateTimeKind.Local).AddTicks(9334), "Weasley" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reason");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
