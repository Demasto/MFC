using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreInfoAboutStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DirectionOfStudy",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "INN",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SNILS",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceNumber",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576",
                columns: new[] { "ConcurrencyStamp", "DirectionOfStudy", "Gender", "INN", "Name", "Passport", "PasswordHash", "SNILS", "ServiceNumber" },
                values: new object[] { "d5884b0f-cb0f-4397-8d17-709b0cfef35b", "09.03.01", "Мужской", "7777065424", "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"04.09.2002\",\"DateOfIssue\":\"12.03.2024\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEKNaatziJOal0U+0h2f15sav+dhKcXNGypaPSHXrvdt778gk1W0H3brbtsVb5vOEbQ==", "375232753", "12345678" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e577",
                columns: new[] { "ConcurrencyStamp", "DirectionOfStudy", "Gender", "INN", "Name", "Passport", "PasswordHash", "SNILS", "ServiceNumber" },
                values: new object[] { "f8890809-f9e4-40b4-ab6b-a4455d038b27", "09.03.01", "Мужской", "7777065424", "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"04.09.2002\",\"DateOfIssue\":\"12.03.2024\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEF2v9X0vTvw/ig3lR49FRACujJcDYTFtmN7fsJJUfRpc/pl/WjrKzp/wTfqYB10GnQ==", "375232753", "12345678" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e578",
                columns: new[] { "ConcurrencyStamp", "DirectionOfStudy", "Gender", "INN", "Name", "Passport", "PasswordHash", "SNILS", "ServiceNumber" },
                values: new object[] { "6b7e72e5-8acc-4fe8-a4a2-91029951efc6", "09.03.01", "Женский", "7777065424", "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "{\"Series\":\"4517\",\"Number\":\"543254\",\"UnitCode\":\"432-632\",\"PlaceOfBrith\":\"\\u0413. \\u041C\\u043E\\u0441\\u043A\\u0432\\u0430\",\"DateOfBrith\":\"04.09.2002\",\"DateOfIssue\":\"12.03.2024\",\"Citizenship\":\"\\u0420\\u043E\\u0441\\u0441\\u0438\\u0439\\u0441\\u043A\\u0430\\u044F \\u0424\\u0435\\u0434\\u0435\\u0440\\u0430\\u0446\\u0438\\u044F\"}", "AQAAAAIAAYagAAAAEHTpqWJE5giI0BGL+jBrQG8BUDwMF1fwHvXS60aoJdcmUlbf6DXRh975SbIiJkc2ZA==", "375232753", "12345678" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectionOfStudy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "INN",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SNILS",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ServiceNumber",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f4ddbd2-fc20-4714-895d-89109e3b98eb", "AQAAAAIAAYagAAAAEIl6YikUIOHh8STQ5hWy6ifBq1fFvEsQv3Z2x9DgkkWssT62lshTB4SjjSBfVQWQcA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e577",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c9e3e2d-738d-47f6-b9bb-97f255d66749", "AQAAAAIAAYagAAAAEEEDjhb5xX4XyPag250B6Cd9XT4g2FTrwnNVqacVuIj22YpvmPRpEb2fCbMzodUSpg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e578",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd8e83c1-dbaa-49e8-a2f1-3972dea39fd6", "AQAAAAIAAYagAAAAECrPUxq1AJsxvvkX5f+EKcg+Zmu294KAINekjFT4vcvC6LnJKcqwGIyM6aUNMsAlhg==" });
        }
    }
}
