using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class onPublic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Services");

            migrationBuilder.AddColumn<bool>(
                name: "OnPublic",
                table: "Services",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba8311c4-a9b8-470c-a2fe-658e34bb5be6", "NASTYA@EXAMPLE.COM", "NASTYA@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIITTFUrPKxS3NufmXRkbzGIBfFjgbyQyxfv62FxEuYowqZ9fDOxryw8jxmm5znPsQ==", "a1eb9086-b499-47ef-ab4f-036a3b25f44a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98362ef5-8879-4162-b16f-cf7096842a3c", "AQAAAAIAAYagAAAAEDDtiykq2sNXBhv+4gxsFJ6/pEmSJ3lCZoPcl7oC6VXUCLdLL/bK7OByA5Om8kjkVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baab30ef-65d3-4187-ac92-61003612999d", "DMITRY@EXAMPLE.COM", "DMITRY@EXAMPLE.COM", "AQAAAAIAAYagAAAAELsSt92To8PIwy7jmTVi5uuBMl9x6ehKlzv4pVRhAzYCPipONeRU/rTA6pMO+48chw==", "69b2ed9b-f9f8-4d3c-896a-92fcc8ee65b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad61be68-7efc-4011-90cd-67680a640cf5", "AQAAAAIAAYagAAAAEDpRyfHqxPhRfDJTwmJjz70LuCkmBzQS1dVUH6SwVmleEqugKr5VCQVVNCgCpF4RUA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnPublic",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90106a01-b579-45c9-b35d-8d3331e26525", null, null, "AQAAAAIAAYagAAAAECrhfFQcVmtV+HN1IZNQLaC9puxCFfVWM0GuBP30vV//WSF2amilg3IzGI4xeZU2nQ==", "96e2e157-2f4a-449e-bfa5-b5e758d9af50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f4c014e-9ae5-4113-bb78-a5ce9d124739", "AQAAAAIAAYagAAAAEMRbXK+02tgNGdPSHs3QoUPj2tzfOr0ZaME2HCcjK8CSyEBl9KMvnXSYt0zmU8Qo8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "240b035c-6e65-49f5-bd0b-28edbba27c19", null, null, "AQAAAAIAAYagAAAAEKo8365lyTATq58VKmUtkfqoPS1SryIDYTdUBh3NN2uBMGhsdI5aGK3kJrQM3lkIaA==", "98426109-ea48-4d27-aa67-70b1b00481b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e5e1469-7cf7-49b8-b39a-35037814c663", "AQAAAAIAAYagAAAAEHRRy86bvLzXe9Zs6u9EfQGj8/EwWxCa0QZwXa+hA86AX66cYreO6Krqyz8VrWNA1A==" });
        }
    }
}
