using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Tasks",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a26dc49a-e5c6-408b-a32a-4b612ff99b28", "AQAAAAIAAYagAAAAEEdxaFALOeRGP3FVPUK4v18tJKadyQIBMlhEy2Xki/tzF9cKaezd/gneUIhtZEWtLw==", "54ac5a39-a463-4028-aa83-98c5d72484d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Т38be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4e6557d-9bcf-4b00-ad87-98b2e9ae05c4", "AQAAAAIAAYagAAAAEPpfiT+zQ4er+sxwP876OssUq1Xi18RrCJSVgzV1XFaczSCeuTdmQ2W9uLJUJ2BAbA==", "4086ca9e-ed53-4060-a533-148765a7623e" });

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
        }
    }
}
