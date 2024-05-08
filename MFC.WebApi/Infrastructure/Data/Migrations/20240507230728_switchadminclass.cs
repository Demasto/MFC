using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class switchadminclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7576069-fafe-4c37-a077-a8d8b21ec0ae", "AQAAAAIAAYagAAAAEBhNx6ogdKddIkPfQG4iMyFxUTTcFEU4KVAIPptVd2PhB/VblCI3S9jpDkBdX2Cvnw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91fd9574-5eca-45df-bc8e-d0a5a020a3c0", "AQAAAAIAAYagAAAAEF0S9XFgIq0KQCUX75p5MxppAItV+k3urIoy8qx1421rHkutiaGclU778Ktlpzv76g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6767ac7c-e8ec-4986-bc7c-e0d8ec4e59f3", "AQAAAAIAAYagAAAAEDBqmuzkgOYuLwyK2/ejCAtir+lOzfXLI7ic/JaNsBo/BCVY7gykqe5OTo1XTITShQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b18be9c0-aa65-4af8-bd17-10bd9344e586", 0, "963b5e29-c5d3-43a1-ad1e-b5d4e8c38981", "09.03.01", "StudentUser", "admin@example.com", false, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "ADMIN@EXAMPLE.COM", "ADMIN", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEJ6wNIreEWu7BwCThdE/63U2N6zptsl0WWOII7RrjMgjwIZ84F0WuBzvM/UR3VqB7g==", null, false, "375232753", "", "12345678", false, "admin" });
        }
    }
}
