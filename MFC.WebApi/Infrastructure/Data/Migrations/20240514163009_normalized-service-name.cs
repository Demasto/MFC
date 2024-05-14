using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class normalizedservicename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d66742f-2ee6-4673-a594-7196961582fb", "AQAAAAIAAYagAAAAEPADSxmQIHiai/+Y6k38zoKdkmonKhTA+vfxJXe3I0qRzWEqNFsEhvuoDdg3j46wVA==", "63f6ec47-dbbd-410b-8fbd-a7b4c7ab903d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ce2f1a3-b5bc-43ea-9b9f-3372e8d849a9", "AQAAAAIAAYagAAAAENAmDUM3mkTlKGqpxsGuNBnr/xf+Iy9hJ7tNetdZYPisML8LATgYwVpY92R2c8+ejA==", "0023b6b2-712d-4ac9-b10f-1ca83947e52e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e92fcbd0-e0ec-4f8d-923a-59362070db9f", "AQAAAAIAAYagAAAAEPhQ6W9HD/YMNg3yvDK8RBgol9ien6rneB4uI97FV8oah4Apx+J/uM61CbzWAJPneg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b6b651c-6546-4814-9052-37054f7852fc", "AQAAAAIAAYagAAAAEO/gmo7aeMEcgxIdUOs8zEztTjowFWMs7M/eSn3yxXZeWkcI5f6dySJrKb36rPvzgg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "Services");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c519064-aca9-48c9-969f-10b20b126434", "AQAAAAIAAYagAAAAEM7CvPFZg47SnAr37tUJgYyEziezhBjov3JiHDKHftMCfeG3Ib1eUS9oEskkeHGzsw==", "f57891ce-c6fc-459d-b572-3b073adcdffc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4c38547-c633-4759-af68-71ddd2b8f444", "AQAAAAIAAYagAAAAEMQs3gPB+mZoiivZgwg7eQg9gnF5AlIOnEetLxMSSc8D2ZJg+olZRxjDR8x2u/GPkw==", "daa70e96-0c82-430f-8b1f-64484499e9c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fbfd945f-e28d-4460-bf1e-a115794497e7", "AQAAAAIAAYagAAAAEDW25jb63vxwpq9Rb+93hr1gvUBh2VHg2Sxv9EydXDV5CzaSjtlq3PL16rEEc/QXbw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d28be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8bb9332d-474f-4f2b-9ae3-e9a33e259719", "AQAAAAIAAYagAAAAEAa6tLlR/8n1//DkcjkAFNfuyRlamfblMnPi6/YagAmi5NF4qF+aGQFVI1ad/qzAzw==" });
        }
    }
}
