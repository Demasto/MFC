using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class revorked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "Tasks",
                newName: "Service");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Tasks",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "738be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15616fd5-b430-44b7-a076-d272b0d68d5a", "AQAAAAIAAYagAAAAED3lDpBfCWnwlhzHwwhBWzScaII20psi18PThpaEFdIRxNnGw/wOCwDk5U4MorZFWQ==", "314356dd-c29f-4e85-8742-61501be1df90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "738be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac81fe86-ce12-4aa8-9617-f0efe74c1649", "AQAAAAIAAYagAAAAEFeapgUT+U1A8CH7O94oICDtOAheoZJJhTNZe6zmBG18ZpwfQllkYDdk204HqGRt+A==", "e5f463e2-e0d3-4c1b-ab4b-1fa6ed1d7f79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5aa47f9c-dd24-494e-b447-40b0f4eab90b", "AQAAAAIAAYagAAAAECgD8VKIShoEfGiXc6PpAkwylDSR/gYHmxK9hE0+3Fp7uG6yzawbi6ztvzKGMIn93Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "256c556a-f7fe-499f-9eac-d2b69d979643", "AQAAAAIAAYagAAAAEDmWlSVwLFbWHEyvfUYF7Ji2kXRhs4nekNwP1rzCRTEQx12dfHl5qv8I+Qa+102QrQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Service",
                table: "Tasks",
                newName: "ServiceName");

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "738be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50c1badb-9008-42b1-93cf-8396aa28b01f", "AQAAAAIAAYagAAAAEKaet7l4ugxbaK0CBr+EUj2inZgi5kKcjcdmTFAcbszq1tYhsllYTbPtQyhehP3K9Q==", "b4e354b7-8abd-4c16-b40e-fbb0c0af8d09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "738be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f83a8126-65d6-476a-8946-aa1fc77a7dc7", "AQAAAAIAAYagAAAAEPeSs9J785uuGKrcy/E3gZjNfcfErPwQFkAxM+AqgzWqgfn14ASeR7m0Wkx0lF1lbA==", "4efdf577-a6ad-4f92-94e0-9f2adcd13aa8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fbbbfd0-20c9-4c33-8c53-7afaaddf442c", "AQAAAAIAAYagAAAAENErwN8ymwCOj1Sq5vLieFAgRxP7CoNXBrWKm17HzHc2gEi2HqxLTCFfIuRqapHgXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0cc84d29-69ba-4e7b-b117-5d61cf10cda3", "AQAAAAIAAYagAAAAEBJIX0FYEL1yrHkbSbKzWGi6t+ufJgPRW/pgbSnrdEx/xPvzr3yxRCrDeueo7D3L5A==" });
        }
    }
}
