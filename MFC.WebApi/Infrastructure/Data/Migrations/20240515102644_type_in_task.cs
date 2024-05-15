using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class type_in_task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4896f892-5796-4f64-9433-c4203cfecc05", "AQAAAAIAAYagAAAAENxwPwNJQXcH1TzJ801P58pquPWBCfemMFBwonuS9UD6XePpIM1YXJG2FHTRYW5/7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65e82409-0aa5-4abb-bff4-7322ae142d64", "AQAAAAIAAYagAAAAEApOdfu1TbQuY+k1wYWQMTYP36Q7XEFhjnurFn6/42w7gS6E58T7S2o4wz7HyokvtA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "232638e6-4e42-455c-8aad-87cb623c07d9", "AQAAAAIAAYagAAAAEPxf5thYkZcBxUKAFrUCv5Hkxh2vqxN8a8kbq/ujQifM1o/bt4eU+DMYN6C3zYLI5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a4d4675-20bb-4f1a-b7a5-5c9915c11f37", "AQAAAAIAAYagAAAAEPmb+HpsNvZTZC6Oe2bDne41OqxEYWhztBJv4TWcfBqv62frQw4s+hSV49avvEo9fA==" });
        }
    }
}
