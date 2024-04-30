using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f446",
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f447", null, "student", "STUDENT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576",
                columns: new[] { "ConcurrencyStamp", "Group", "PasswordHash" },
                values: new object[] { "8f4ddbd2-fc20-4714-895d-89109e3b98eb", "УВП-411", "AQAAAAIAAYagAAAAEIl6YikUIOHh8STQ5hWy6ifBq1fFvEsQv3Z2x9DgkkWssT62lshTB4SjjSBfVQWQcA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Group", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e577", 0, "1c9e3e2d-738d-47f6-b9bb-97f255d66749", "Dmitry@example.com", false, "УВП-411", false, null, "DMITRY@EXAMPLE.COM", "DMITRY", "AQAAAAIAAYagAAAAEEEDjhb5xX4XyPag250B6Cd9XT4g2FTrwnNVqacVuIj22YpvmPRpEb2fCbMzodUSpg==", null, false, "", false, "Dmitry" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e578", 0, "bd8e83c1-dbaa-49e8-a2f1-3972dea39fd6", "Nastya@example.com", false, "УВП-411", false, null, "NASTYA@EXAMPLE.COM", "NASTYA", "AQAAAAIAAYagAAAAECrPUxq1AJsxvvkX5f+EKcg+Zmu294KAINekjFT4vcvC6LnJKcqwGIyM6aUNMsAlhg==", null, false, "", false, "Nastya" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e577" },
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e578" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e577" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e578" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f447");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e577");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e578");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f446",
                column: "NormalizedName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576",
                columns: new[] { "ConcurrencyStamp", "Group", "PasswordHash" },
                values: new object[] { "7b4ac2a9-fcb9-47f8-8766-4181f1751543", "null", "AQAAAAIAAYagAAAAELaTTD0iO7rlgOA/sF0VoT8QIrHxg/rGdMhuj0bIN8D+b4OdDM7thTwwQiH/yeilvA==" });
        }
    }
}
