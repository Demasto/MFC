using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class studentProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormOfStudy",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "FormOfStudy", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90106a01-b579-45c9-b35d-8d3331e26525", 0, "AQAAAAIAAYagAAAAECrhfFQcVmtV+HN1IZNQLaC9puxCFfVWM0GuBP30vV//WSF2amilg3IzGI4xeZU2nQ==", "96e2e157-2f4a-449e-bfa5-b5e758d9af50" });

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
                columns: new[] { "ConcurrencyStamp", "FormOfStudy", "PasswordHash", "SecurityStamp" },
                values: new object[] { "240b035c-6e65-49f5-bd0b-28edbba27c19", 0, "AQAAAAIAAYagAAAAEKo8365lyTATq58VKmUtkfqoPS1SryIDYTdUBh3NN2uBMGhsdI5aGK3kJrQM3lkIaA==", "98426109-ea48-4d27-aa67-70b1b00481b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e5e1469-7cf7-49b8-b39a-35037814c663", "AQAAAAIAAYagAAAAEHRRy86bvLzXe9Zs6u9EfQGj8/EwWxCa0QZwXa+hA86AX66cYreO6Krqyz8VrWNA1A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormOfStudy",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88cb2626-364a-4072-bf54-4c05b9bbc8ef", "AQAAAAIAAYagAAAAENmfsULBsk6CTpPtACu6qMnkvXvd38kOpA8XRSwI9056wBVWnSQuTlREBpYhpSGEfQ==", "0ec15b75-d307-41df-be50-28d4a4991b54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "78f4975b-450d-42ff-b2c6-a7352b4c0435", "AQAAAAIAAYagAAAAEGYCuLJG7jUWzKBfn8dX06s5OWn1AdMaZTZweqxEz++NnnqZAeyJZMOyuQTOuFWBxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb221e1d-3e61-4cb8-aa76-23e9cd10800f", "AQAAAAIAAYagAAAAEIvVxAmUmXJ58v41n8oXy3ZWdtYz4oQhoZxl0VscfjjtCIakKCLpFaeX1T6V2Lg3jg==", "15df752f-c524-4942-b6b5-a2eecfe87711" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57af7296-0456-4c8b-b114-cd805241af7f", "AQAAAAIAAYagAAAAEJtZxDVsi8FQyadul77yMUlCGj4qoD952ip/X7hoFYdBf4aw+KEO9Nw9cWyqbiTWWA==" });
        }
    }
}
