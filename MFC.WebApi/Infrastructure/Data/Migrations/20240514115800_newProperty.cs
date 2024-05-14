using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "d28be9c0-aa65-4af8-1d17-10bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "d28be9c0-aa65-4af8-bd17-10bd9344e587" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-1d17-10bd9344e588");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e587");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "Tasks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3e805b3-ec42-4d88-93d1-9bd5d653c402", "AQAAAAIAAYagAAAAEBkKw7oGTfmviCyNnIoaFnTRMxy8IAakj51ie7WfXo23as4PLxVDIcwUAsiNa+Ld1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63338284-444c-4256-896d-06623b55cbf0", "AQAAAAIAAYagAAAAEMtNyCmJ3c3DBvGgnDkz/8BtghSdmdTjrslKZyktgQ/7mUgoq9V0vCdfVG7ZG9rgGQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfEnrollment", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "FormOfStudy", "GapYearsCount", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "Т38be9c0-aa65-4af8-1d17-10bd9344e588", 0, "a26dc49a-e5c6-408b-a32a-4b612ff99b28", new DateOnly(2020, 8, 12), "09.03.01", "StudentUser", "Nastya@example.com", false, 0, 0, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "NASTYA@EXAMPLE.COM", "NASTYA", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEEdxaFALOeRGP3FVPUK4v18tJKadyQIBMlhEy2Xki/tzF9cKaezd/gneUIhtZEWtLw==", null, false, "375232753", "54ac5a39-a463-4028-aa83-98c5d72484d6", "87654321", false, "Nastya" },
                    { "Т38be9c0-aa65-4af8-bd17-10bd9344e587", 0, "f4e6557d-9bcf-4b00-ad87-98b2e9ae05c4", new DateOnly(2020, 8, 12), "09.03.01", "StudentUser", "Dmitry@example.com", false, 0, 0, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "DMITRY@EXAMPLE.COM", "DMITRY", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEPpfiT+zQ4er+sxwP876OssUq1Xi18RrCJSVgzV1XFaczSCeuTdmQ2W9uLJUJ2BAbA==", null, false, "375232753", "4086ca9e-ed53-4060-a533-148765a7623e", "12345678", false, "Dmitry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "Т38be9c0-aa65-4af8-1d17-10bd9344e588" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "Т38be9c0-aa65-4af8-bd17-10bd9344e587" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "Т38be9c0-aa65-4af8-1d17-10bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "Т38be9c0-aa65-4af8-bd17-10bd9344e587" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-1d17-10bd9344e588");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-bd17-10bd9344e587");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98362ef5-8879-4162-b16f-cf7096842a3c", "AQAAAAIAAYagAAAAEDDtiykq2sNXBhv+4gxsFJ6/pEmSJ3lCZoPcl7oC6VXUCLdLL/bK7OByA5Om8kjkVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad61be68-7efc-4011-90cd-67680a640cf5", "AQAAAAIAAYagAAAAEDpRyfHqxPhRfDJTwmJjz70LuCkmBzQS1dVUH6SwVmleEqugKr5VCQVVNCgCpF4RUA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfEnrollment", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "FormOfStudy", "GapYearsCount", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d28be9c0-aa65-4af8-1d17-10bd9344e588", 0, "ba8311c4-a9b8-470c-a2fe-658e34bb5be6", new DateOnly(2020, 8, 12), "09.03.01", "StudentUser", "Nastya@example.com", false, 0, 0, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "NASTYA@EXAMPLE.COM", "NASTYA@EXAMPLE.COM", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEIITTFUrPKxS3NufmXRkbzGIBfFjgbyQyxfv62FxEuYowqZ9fDOxryw8jxmm5znPsQ==", null, false, "375232753", "a1eb9086-b499-47ef-ab4f-036a3b25f44a", "12345678", false, "Nastya" },
                    { "d28be9c0-aa65-4af8-bd17-10bd9344e587", 0, "baab30ef-65d3-4187-ac92-61003612999d", new DateOnly(2020, 8, 12), "09.03.01", "StudentUser", "Dmitry@example.com", false, 0, 0, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "DMITRY@EXAMPLE.COM", "DMITRY@EXAMPLE.COM", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAELsSt92To8PIwy7jmTVi5uuBMl9x6ehKlzv4pVRhAzYCPipONeRU/rTA6pMO+48chw==", null, false, "375232753", "69b2ed9b-f9f8-4d3c-896a-92fcc8ee65b6", "12345678", false, "Dmitry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "d28be9c0-aa65-4af8-1d17-10bd9344e588" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "d28be9c0-aa65-4af8-bd17-10bd9344e587" }
                });
        }
    }
}
