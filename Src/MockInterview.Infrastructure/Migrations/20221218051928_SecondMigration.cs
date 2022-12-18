using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockInterview.Infrastructure.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("42c6d39d-3a48-4d68-8b94-30f40b311a59"));

            migrationBuilder.AddColumn<string>(
                name: "LinkInterView",
                table: "Interviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RegisterDate",
                table: "Clients",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Experience", "FirstName", "ImagePath", "IsActive", "LastModifiedDate", "LastName", "Level", "Login", "Password", "PhoneNumber", "Role", "UpdatedBy" },
                values: new object[] { new Guid("da917ad5-1b83-47b8-8507-98f199c4ba3a"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2022, 12, 18, 10, 19, 27, 858, DateTimeKind.Unspecified).AddTicks(8061), new TimeSpan(0, 5, 0, 0, 0)), new TimeSpan(0, 0, 0, 0, 0), "Nodirxon", null, true, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Abdumurotov", 0, "admin", "admin", "1111", 0, new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("da917ad5-1b83-47b8-8507-98f199c4ba3a"));

            migrationBuilder.DropColumn(
                name: "LinkInterView",
                table: "Interviews");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreatedDate", "Experience", "FirstName", "ImagePath", "IsActive", "LastModifiedDate", "LastName", "Level", "Login", "Password", "PhoneNumber", "Role", "UpdatedBy" },
                values: new object[] { new Guid("42c6d39d-3a48-4d68-8b94-30f40b311a59"), null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2022, 12, 18, 0, 48, 6, 546, DateTimeKind.Unspecified).AddTicks(7047), new TimeSpan(0, 5, 0, 0, 0)), new TimeSpan(0, 0, 0, 0, 0), "Nodirxon", null, true, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Abdumurotov", 0, "admin", "admin", "1111", 0, new Guid("00000000-0000-0000-0000-000000000000") });
        }
    }
}
