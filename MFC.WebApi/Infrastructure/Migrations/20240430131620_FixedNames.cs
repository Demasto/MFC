using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b19f0ebd-20f4-4983-8574-201c01f61ec1", "AQAAAAIAAYagAAAAEGR+Uf1AgbeP5WLSzlLwdYSuWDqnC5w7Q2L+H6Y78ly6nBh1KsRH8MBTks+nbaithQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e577",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "ea45b1e6-2ac4-4de8-883b-068fbf11de37", "{\"First\":\"\\u0414\\u043C\\u0438\\u0442\\u0440\\u0438\\u0439\",\"Second\":\"\\u0411\\u043E\\u043B\\u0442\\u0430\\u0447\\u0435\\u0432\",\"Middle\":\"\\u041C\\u0438\\u0445\\u0430\\u0439\\u043B\\u043E\\u0432\\u0438\\u0447\"}", "AQAAAAIAAYagAAAAEAWgVAey5dWcgugAkkC7FGyZdfOVxu5v5p/4jMS+GN5f0cJqxt1MwgSX+IRifgYKRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e578",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "c691ee53-bafe-42d3-8b31-19dbc075cbec", "{\"First\":\"\\u0410\\u043D\\u0430\\u0441\\u0442\\u0430\\u0441\\u0438\\u044F\",\"Second\":\"\\u041A\\u043E\\u043D\\u0441\\u0442\\u0430\\u043D\\u0442\\u0438\\u043D\\u043E\\u0432\\u0430\",\"Middle\":\"\\u0412\\u0438\\u0442\\u0430\\u043B\\u044C\\u0435\\u0432\\u043D\\u0430\"}", "AQAAAAIAAYagAAAAEBQwofub9B6oa+cW0XDfDBZ3h+sxX6/k6EvjBXnNNvQhpMOcOGAksEHz91r1CIPvtQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e576",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5884b0f-cb0f-4397-8d17-709b0cfef35b", "AQAAAAIAAYagAAAAEKNaatziJOal0U+0h2f15sav+dhKcXNGypaPSHXrvdt778gk1W0H3brbtsVb5vOEbQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e577",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "f8890809-f9e4-40b4-ab6b-a4455d038b27", "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "AQAAAAIAAYagAAAAEF2v9X0vTvw/ig3lR49FRACujJcDYTFtmN7fsJJUfRpc/pl/WjrKzp/wTfqYB10GnQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e578",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "6b7e72e5-8acc-4fe8-a4a2-91029951efc6", "{\"First\":\"Admin\",\"Second\":\"Adminov\",\"Middle\":\"Adminovich\"}", "AQAAAAIAAYagAAAAEHTpqWJE5giI0BGL+jBrQG8BUDwMF1fwHvXS60aoJdcmUlbf6DXRh975SbIiJkc2ZA==" });
        }
    }
}
