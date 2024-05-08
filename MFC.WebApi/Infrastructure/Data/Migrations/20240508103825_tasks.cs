using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormOfStudy",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTask",
                columns: table => new
                {
                    TasksId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTask", x => new { x.TasksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserTask_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "FormOfStudy", "PasswordHash" },
                values: new object[] { "c69d6db3-c173-4100-9a19-f41c5068b4c6", "очная", "AQAAAAIAAYagAAAAEPnPxv2ielCrUy6UmvReA95rSl4Ma7vn6l1zkX+2y4A9bHexRur49WIeAveChvCgHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "FormOfStudy", "PasswordHash" },
                values: new object[] { "eb06e421-de1f-4463-a86f-aff32cec7082", "очная", "AQAAAAIAAYagAAAAEEvaJwq/c2CFEddOTbPfXtmG8Iumx/PWXiuAbwkAh4LTEibdDloEP6CSDT2d8O7/8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b9e8ade-1b73-4359-bc45-4f9c69eaa287", "AQAAAAIAAYagAAAAED5gYHFtrZhLxTfSYz/NhwfovRXOjcJRnhO+Q0g8PyPlX+r0Q4jUghyITtq6veg8nw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f69004fd-c54a-4dbc-9a77-a38bc2bbbdd4", "AQAAAAIAAYagAAAAEId8p+4M/dDhhuyIDbJ4JAU+bbq9s1Ckl/tLoDz9FiIuEBz7z0M+/eZw7vbTtZ+k0w==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTask_UsersId",
                table: "AppUserTask",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserTask");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropColumn(
                name: "FormOfStudy",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f728f52b-5598-41ef-af01-69afd00752d6", "AQAAAAIAAYagAAAAEMemz6jBuxMQMeYWr9j77Pn09XBb16kbHYlCUzWee3na/Rvfr77uPRUtbCLdp/p1og==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cfa32fd5-b3d2-437f-85b9-671824f86fd5", "AQAAAAIAAYagAAAAEN/X6IQJ/eB+OWKdXkV48G+iMgE5Z3u71b/NwYPDjp8Zc3+NG5pL622udI+JUTxNsw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc393f99-d984-455d-bba0-8017f1400768", "AQAAAAIAAYagAAAAEGxzMi0VQcI3AEGYFy8PURBXEJNLfz148/O9bDuCPlutAN9ypWZwQc0VexiJfSHe+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "274e8c7e-b6a9-416f-ad58-bab04bca3a6a", "AQAAAAIAAYagAAAAEN6yg4kXryprhVNiwp5vX7NCnGXnr7sZJIGCiids1OsWzqFUzzCsEK1GQTbiQBx1+w==" });
        }
    }
}
