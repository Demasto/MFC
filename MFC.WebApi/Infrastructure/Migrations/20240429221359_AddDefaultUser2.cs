using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "9631f3d6-1df1-4e81-af36-fd235d343553", "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEO2VBhlfDkuq/YpMUww9O/lKjRTqQ3Vpz+nMuBC9Ow8NP2W53LGAy9XYh55E4ez8aA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "b9121a39-9bd9-4986-bfcb-6ca3c473d67f", "admin@example.com", "admin", "AQAAAAIAAYagAAAAEAYWn3cy8aeqcbwNYPNhMrIqk2/nMxdnA+vp0YTt8uu5aU5rUxBMdl2sWDMT0vTV6A==" });
        }
    }
}
