using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @switch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f446", "b18be9c0-aa65-4af8-bd17-10bd9344e586" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f728f52b-5598-41ef-af01-69afd00752d6", "AQAAAAIAAYagAAAAEMemz6jBuxMQMeYWr9j77Pn09XBb16kbHYlCUzWee3na/Rvfr77uPRUtbCLdp/p1og==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cfa32fd5-b3d2-437f-85b9-671824f86fd5", "AQAAAAIAAYagAAAAEN/X6IQJ/eB+OWKdXkV48G+iMgE5Z3u71b/NwYPDjp8Zc3+NG5pL622udI+JUTxNsw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc393f99-d984-455d-bba0-8017f1400768", "AQAAAAIAAYagAAAAEGxzMi0VQcI3AEGYFy8PURBXEJNLfz148/O9bDuCPlutAN9ypWZwQc0VexiJfSHe+Q==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Gender", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c18be9c0-aa65-4af8-bd17-10bd9344e586", 0, "274e8c7e-b6a9-416f-ad58-bab04bca3a6a", "AppUser", "admin@example.com", false, "admin", "7777065424", false, null, "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "ADMIN@EXAMPLE.COM", "ADMIN", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEN6yg4kXryprhVNiwp5vX7NCnGXnr7sZJIGCiids1OsWzqFUzzCsEK1GQTbiQBx1+w==", null, false, "375232753", "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f446", "c18be9c0-aa65-4af8-bd17-10bd9344e586" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f446", "c18be9c0-aa65-4af8-bd17-10bd9344e586" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-bd17-10bd9344e586");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "28b09624-2f3d-4f3f-aff5-9bc4f22d3394", "AQAAAAIAAYagAAAAEIcpW8NR6EBieX57yZkO5WY3epIWvQxmayaTtHdUbhjBqB+NChsYPdQgrFALgvewFw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d154b5a-e791-44a8-8224-b315dc67f7e6", "AQAAAAIAAYagAAAAEJBaRKNZ1rOAHqC1samaTzgVuInb1wnOygw3cGgZSOoiNj1FbhO6aHKE42xi94rvrg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e48c6b7d-19cd-42e5-838c-2dc4799aad87", "AQAAAAIAAYagAAAAEFiVtHxD5PXuh97VP4tu2NC9qeHRyJapVVvuAKZHoOW39A2N/Ow/gjPD6xCiUmEbVw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Gender", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b18be9c0-aa65-4af8-bd17-10bd9344e586", 0, "58e42454-2324-43f0-ad29-f06f3882234b", "AppUser", "admin@example.com", false, "admin", "7777065424", false, null, "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "ADMIN@EXAMPLE.COM", "ADMIN", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAENLk6SScGq8gqd2K1LRdYHg3QVSL/ahYFmwAbXB2zHYhcff/+TueX0Izbc8Gn1ytVA==", null, false, "375232753", "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f446", "b18be9c0-aa65-4af8-bd17-10bd9344e586" });
        }
    }
}
