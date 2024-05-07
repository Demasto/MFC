using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2efb2cc4-dfaa-45cb-a2c2-912f7c3e6280", "AQAAAAIAAYagAAAAEH+hmBOGPSrArKDAR9xseyMTPvUXDCkE6nwIRmkT6CLRh+aki4SfJnPgdEJzUElcpQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "495e41c2-cd1a-4fd1-8f39-a20a95dbddb8", "AQAAAAIAAYagAAAAEIXZim40WZbnDr94DQDhL92+9mNDpIA/89zLBtm7OjbQTIudTP51yZQAShxswx4qyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ddbf3265-18e9-45b7-a536-503b55354ec3", "AQAAAAIAAYagAAAAEIeqALYh1pgRtS8oM3CU3Yb1ze7ZWYc98cRFuGW4UBGQEs7VjT5Bl56Yv9eeg7fstg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff9b0260-2a86-43b3-a890-e8835fb58ae8", "AQAAAAIAAYagAAAAENshJX1y426RJSgdoMQzrP1Dxb2S4xP4EIalgpETCPTmU58E6uuotrueDTLOrzk1YA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

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
    }
}
