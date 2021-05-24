using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddingDomainObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "JoinDate",
                value: new DateTime(2019, 5, 23, 19, 19, 10, 781, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2020, 5, 23, 19, 19, 10, 783, DateTimeKind.Local).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "JoinDate",
                value: new DateTime(2021, 3, 23, 19, 19, 10, 783, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "JoinDate",
                value: new DateTime(2020, 2, 23, 19, 19, 10, 783, DateTimeKind.Local).AddTicks(3252));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2021, 5, 23, 17, 9, 25, 342, DateTimeKind.Local).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2021, 5, 23, 17, 9, 25, 343, DateTimeKind.Local).AddTicks(1166));

            migrationBuilder.UpdateData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2021, 5, 23, 17, 9, 25, 343, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "JoinDate",
                value: new DateTime(2019, 5, 23, 17, 9, 25, 340, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "JoinDate",
                value: new DateTime(2020, 5, 23, 17, 9, 25, 341, DateTimeKind.Local).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "JoinDate",
                value: new DateTime(2021, 3, 23, 17, 9, 25, 341, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "JoinDate",
                value: new DateTime(2020, 2, 23, 17, 9, 25, 341, DateTimeKind.Local).AddTicks(9334));
        }
    }
}
