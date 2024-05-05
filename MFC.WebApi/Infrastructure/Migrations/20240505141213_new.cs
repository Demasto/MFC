using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c0d0dc3-fdb8-48f7-917e-148d069ea785", "AQAAAAIAAYagAAAAEIIwIP0rQ3ziwDypheU4bnqS82zKLJCWGwVprZEAds+ZHcn5kxPU1JGyqrxeEyMC7Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83d584e3-9995-4dc7-902a-9c7321e272a7", "AQAAAAIAAYagAAAAEEDPvuqGoInWdp5F0bYmW2eobeDSUHjwnpw+gOB7bhxK3ZG6A70czqqz+QKsO0Oabg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e3c7127-5b70-41b7-976f-ed3343d1e466", "AQAAAAIAAYagAAAAEL9VVJwT2KThUfL27fgwdXogdEIU2jEM3jsu8BaBsAUjLYUUHAmoG3vSYoVDR1KBew==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8d5cc17-a573-498a-82bc-d4e46897733b", "AQAAAAIAAYagAAAAEIRB+doACE7ZcjV25R2emEaHeOPVLowci3hwf1gWfuy3BVjLXAg+I8f4MxpcLFjSTQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a245adf-251a-49a7-9ac7-f5f94e385175", "AQAAAAIAAYagAAAAEIGzzhIM9Spe/CwkxXFSl/nltxLDxnAj4MDEBqo4TdcrxzSqZlgMaEc0hzWKSdarSQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a69f8d16-778c-477a-9545-a620864bf20c", "AQAAAAIAAYagAAAAEG+ZUUXJtSPdwSTA0KC03D2QuIijX3Zm/Z3YVEWdz0sspuIfpd2GGN0Ew8sLQjzMZg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9382db38-f9af-4eae-887e-e510c5b5c8d7", "AQAAAAIAAYagAAAAEHszwZlvmj9nrToe6ZK+QOF8iv/hpy+4nnTNstIClD8YTjQ3wJ4Jyuo/socQxDA17g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e84f4957-dd35-4300-bffb-265216bf37b2", "AQAAAAIAAYagAAAAEEMRyKiTe3Rrw8HjsGSUwFPzVRbmyn1WRKkxnYqJPrtyxiKjqBuDmTELppZo3SRBXg==" });
        }
    }
}
