using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tasks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-1d17-10bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-bd17-10bd9344e587" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4766231-b873-4774-9155-5fb377f4494a", "AQAAAAIAAYagAAAAEJ0eXkm4ReRAAfQTbNWY5ORvIn81taarI69OXNNfbrNjYSNCTdTd7Yz40mRdWX2lhg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d04fa3e-e395-4a01-a49f-ede2608cebd0", "AQAAAAIAAYagAAAAEHR8SqhWsV/1Kf3waB5J8HErFZWH6/1H8PDMU81b7C/pHOldEWfOucazU4VT7tTFoQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "FormOfStudy", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c18be9c0-aa65-4af8-1d17-10bd9344e588", 0, "0973f867-c908-4a7f-b0d1-688d5355c956", "09.03.01", "StudentUser", "Nastya@example.com", false, "очная", "Женский", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "NASTYA@EXAMPLE.COM", "NASTYA", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEI/SAbvIOlcunLbvd7yGQPhIPiBaP0rlAxXKzUU3yCkYufOcHiFtCbiFcpa/NNynog==", null, false, "375232753", "", "12345678", false, "Nastya" },
                    { "c18be9c0-aa65-4af8-bd17-10bd9344e587", 0, "faa7c655-362a-4660-bc59-5d07e5a21978", "09.03.01", "StudentUser", "Dmitry@example.com", false, "очная", "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "DMITRY@EXAMPLE.COM", "DMITRY", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEOHFOnWWnbujuBKlbOC1RgInu+A6BMsN5yjfuGVumPUTFa8rHWdBHhlQ58tBmOB5xQ==", null, false, "375232753", "", "12345678", false, "Dmitry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "c18be9c0-aa65-4af8-1d17-10bd9344e588" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "c18be9c0-aa65-4af8-bd17-10bd9344e587" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "c18be9c0-aa65-4af8-1d17-10bd9344e588" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "c18be9c0-aa65-4af8-bd17-10bd9344e587" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-1d17-10bd9344e588");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-bd17-10bd9344e587");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b9e8ade-1b73-4359-bc45-4f9c69eaa287", "AQAAAAIAAYagAAAAED5gYHFtrZhLxTfSYz/NhwfovRXOjcJRnhO+Q0g8PyPlX+r0Q4jUghyITtq6veg8nw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f69004fd-c54a-4dbc-9a77-a38bc2bbbdd4", "AQAAAAIAAYagAAAAEId8p+4M/dDhhuyIDbJ4JAU+bbq9s1Ckl/tLoDz9FiIuEBz7z0M+/eZw7vbTtZ+k0w==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DirectionOfStudy", "Discriminator", "Email", "EmailConfirmed", "FormOfStudy", "Gender", "Group", "INN", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Passport", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SNILS", "SecurityStamp", "ServiceNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b18be9c0-aa65-4af8-1d17-10bd9344e588", 0, "c69d6db3-c173-4100-9a19-f41c5068b4c6", "09.03.01", "StudentUser", "Nastya@example.com", false, "очная", "Женский", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "NASTYA@EXAMPLE.COM", "NASTYA", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEPnPxv2ielCrUy6UmvReA95rSl4Ma7vn6l1zkX+2y4A9bHexRur49WIeAveChvCgHA==", null, false, "375232753", "", "12345678", false, "Nastya" },
                    { "b18be9c0-aa65-4af8-bd17-10bd9344e587", 0, "eb06e421-de1f-4463-a86f-aff32cec7082", "09.03.01", "StudentUser", "Dmitry@example.com", false, "очная", "Мужской", "УВП-411", "7777065424", false, null, "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "DMITRY@EXAMPLE.COM", "DMITRY", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"2002-02-14\",\"DateOfIssue\":\"2024-12-03\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEEvaJwq/c2CFEddOTbPfXtmG8Iumx/PWXiuAbwkAh4LTEibdDloEP6CSDT2d8O7/8w==", null, false, "375232753", "", "12345678", false, "Dmitry" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-1d17-10bd9344e588" },
                    { "bd376a8f-9eab-4bb9-9fca-40b01540f447", "b18be9c0-aa65-4af8-bd17-10bd9344e587" }
                });
        }
    }
}
