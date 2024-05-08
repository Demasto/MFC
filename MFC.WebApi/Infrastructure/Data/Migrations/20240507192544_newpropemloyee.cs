using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newpropemloyee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Institute",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7576069-fafe-4c37-a077-a8d8b21ec0ae", "AQAAAAIAAYagAAAAEBhNx6ogdKddIkPfQG4iMyFxUTTcFEU4KVAIPptVd2PhB/VblCI3S9jpDkBdX2Cvnw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "963b5e29-c5d3-43a1-ad1e-b5d4e8c38981", "AQAAAAIAAYagAAAAEJ6wNIreEWu7BwCThdE/63U2N6zptsl0WWOII7RrjMgjwIZ84F0WuBzvM/UR3VqB7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91fd9574-5eca-45df-bc8e-d0a5a020a3c0", "AQAAAAIAAYagAAAAEF0S9XFgIq0KQCUX75p5MxppAItV+k3urIoy8qx1421rHkutiaGclU778Ktlpzv76g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "Institute", "PasswordHash" },
                values: new object[] { "6767ac7c-e8ec-4986-bc7c-e0d8ec4e59f3", "", "AQAAAAIAAYagAAAAEDBqmuzkgOYuLwyK2/ejCAtir+lOzfXLI7ic/JaNsBo/BCVY7gykqe5OTo1XTITShQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institute",
                table: "AspNetUsers");

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
    }
}
