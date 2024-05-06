using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd340d27-0de3-4552-a67e-afca68419902");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f446", "a18be9c0-aa65-4af8-bd17-00bd9344e586" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e587" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f447");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e586");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e587");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e588");

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f446", null, "admin", "ADMIN" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", null, "student", "STUDENT" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f448", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b18be9c0-aa65-4af8-1d17-10bd9344e588", 0, "a0a74bd7-3106-4938-b96a-e1e3ee9be9eb", "09.03.01", "StudentUser", "Nastya@example.com", false, "Женский", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "NASTYA@EXAMPLE.COM", "NASTYA", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEFujaCipO1mRgoU2+5bhY/v+aoW/Nm7BpxTzUWYRG7SDwuqwMWVlCymCHNm9x7PU6w==", null, false, "375232753", "", "12345678", false, "Nastya" },
                    { "b18be9c0-aa65-4af8-bd17-10bd9344e586", 0, "ccc3b192-d9b9-4ee6-a413-37f7853f4907", "09.03.01", "StudentUser", "admin@example.com", false, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "ADMIN@EXAMPLE.COM", "ADMIN", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEFXJrA1ILYGPQ75Z4a6HOiQFamDP3FJxqRg3xhx6l2G0OWIEQLYicuOFvZly4054aA==", null, false, "375232753", "", "12345678", false, "admin" },
                    { "b18be9c0-aa65-4af8-bd17-10bd9344e587", 0, "fc7b15e3-e759-4566-89d6-1178bdbd56a4", "09.03.01", "StudentUser", "Dmitry@example.com", false, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "DMITRY@EXAMPLE.COM", "DMITRY", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEPtHXEiTsfWcYxfBdAQvqXGqNaA+Qnk3rJredrJO0uqc/vkhaWInJXWjl1SnSBdjCA==", null, false, "375232753", "", "12345678", false, "Dmitry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Gender", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Post", "SNILS", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b18be9c0-aa65-4af8-bd17-10bd9344e588", 0, "f0628732-7a74-4a33-8015-00eeb65365b8", "EmployeeUser", "employee@example.com", false, "Мужской", "7777065424", false, null, "{\"First\":\"\\u0420\\u0430\\u0431\\u043E\\u0442\\u043D\\u0438\\u043A\",\"Second\":\"\\u041C\\u0418\\u0418\\u0422\\u041E\\u0412\",\"Middle\":\"\\u0418\\u043D\\u0441\\u0442\\u0438\\u0442\\u0443\\u0442\\u043E\\u0432\\u0438\\u0447\"}", "EMPLOYEE@EXAMPLE.COM", "EMPLOYEE", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEE2z7As9egF9ryL1y5pLEMNLdq6WQIHgRWjJ+eLIPwUYZdJSL1W0G9jtkHrg8nt7tA==", null, false, "Доцент", "375232753", "", false, "employee" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-1d17-10bd9344e588" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f446", "b18be9c0-aa65-4af8-bd17-10bd9344e586" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-bd17-10bd9344e587" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f448", "b18be9c0-aa65-4af8-bd17-10bd9344e588" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-1d17-10bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f446", "b18be9c0-aa65-4af8-bd17-10bd9344e586" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-bd17-10bd9344e587" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f448", "b18be9c0-aa65-4af8-bd17-10bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd376a8f-9eab-4bb9-9fca-40b01540f446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd376a8f-9eab-4bb9-9fca-40b01540f447");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd376a8f-9eab-4bb9-9fca-40b01540f448");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f446", null, "admin", "ADMIN" },
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f447", null, "student", "STUDENT" },
                    { "cd340d27-0de3-4552-a67e-afca68419902", null, "employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e586", 0, "83693bc8-a553-4917-9ac5-582423ac3010", "09.03.01", "StudentUser", "admin@example.com", false, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "ADMIN@EXAMPLE.COM", "ADMIN", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEIX2gKordKRHOu2XlMfghAf5+hB1o1kdOx//o7Gjyj/VHsxuUarArxsMqgY31k8okA==", null, false, "375232753", "", "12345678", false, "admin" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e587", 0, "6bb20565-07ae-4f88-9067-6700d635a0f9", "09.03.01", "StudentUser", "Dmitry@example.com", false, "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "DMITRY@EXAMPLE.COM", "DMITRY", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEIrmnWn0OPgLtMZNKAgYmo+H5W6oStkAGNJsree+Zo54iCSSJkT6N8PIy4h4NVJcHw==", null, false, "375232753", "", "12345678", false, "Dmitry" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e588", 0, "3c1a5bad-6a29-4ffe-be54-e877f780104c", "09.03.01", "StudentUser", "Nastya@example.com", false, "Женский", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "NASTYA@EXAMPLE.COM", "NASTYA", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEOLwJmfprShe21GZZn2s5t25WzF7VRxNBAzEFHhlh+VLE5j6tveXyGp0mrWJRWyKwA==", null, false, "375232753", "", "12345678", false, "Nastya" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f446", "a18be9c0-aa65-4af8-bd17-00bd9344e586" },
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e587" },
                    { "ad376a8f-9eab-4bb9-9fca-30b01540f447", "a18be9c0-aa65-4af8-bd17-00bd9344e588" }
                });
        }
    }
}
