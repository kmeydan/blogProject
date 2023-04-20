using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Straßenkarte.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogDescription",
                table: "Blogs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 9, 23, 54, 43, 234, DateTimeKind.Local).AddTicks(9391));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogDescription",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 6, 0, 47, 47, 552, DateTimeKind.Local).AddTicks(2840));
        }
    }
}
