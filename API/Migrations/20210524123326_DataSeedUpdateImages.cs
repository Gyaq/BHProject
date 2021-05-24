using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DataSeedUpdateImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2021, 5, 24, 5, 33, 26, 559, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2021, 5, 24, 5, 33, 26, 559, DateTimeKind.Local).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2021, 5, 24, 5, 33, 26, 559, DateTimeKind.Local).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/commons/thumb/2/26/Robert_Smith_%28musician%29_crop.jpg/1200px-Robert_Smith_%28musician%29_crop.jpg", new DateTime(2019, 5, 24, 5, 33, 26, 556, DateTimeKind.Local).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Sally_Field_%2811205%29_%28cropped%29.jpg/1200px-Sally_Field_%2811205%29_%28cropped%29.jpg", new DateTime(2020, 5, 24, 5, 33, 26, 558, DateTimeKind.Local).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Peter_Gabriel_%283%29_%28cropped%29.jpg/1200px-Peter_Gabriel_%283%29_%28cropped%29.jpg", new DateTime(2021, 3, 24, 5, 33, 26, 558, DateTimeKind.Local).AddTicks(984) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/en/e/e7/Ginny_Weasley_poster.jpg", new DateTime(2020, 2, 24, 5, 33, 26, 558, DateTimeKind.Local).AddTicks(989) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2021, 5, 23, 19, 19, 10, 784, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2021, 5, 23, 19, 19, 10, 784, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2021, 5, 23, 19, 19, 10, 784, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://en.wikipedia.org/wiki/Robert_Smith_(musician)#/media/File:Robert_Smith_(musician)_crop.jpg", new DateTime(2019, 5, 23, 19, 19, 10, 781, DateTimeKind.Local).AddTicks(4348) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://en.wikipedia.org/wiki/Sally_Field#/media/File:Sally_Field_(11205)_(cropped).jpg", new DateTime(2020, 5, 23, 19, 19, 10, 783, DateTimeKind.Local).AddTicks(3223) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://en.wikipedia.org/wiki/Peter_Gabriel#/media/File:Peter_Gabriel_(3)_(cropped).jpg", new DateTime(2021, 3, 23, 19, 19, 10, 783, DateTimeKind.Local).AddTicks(3247) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "JoinDate" },
                values: new object[] { "https://en.wikipedia.org/wiki/Ginny_Weasley#/media/File:Ginny_Weasley_poster.jpg", new DateTime(2020, 2, 23, 19, 19, 10, 783, DateTimeKind.Local).AddTicks(3252) });
        }
    }
}
