using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statement_schemas");

            migrationBuilder.DropTable(
                name: "statements");

            migrationBuilder.AlterColumn<string>(
                name: "SNILS",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SNILS",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "INN",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "statements",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    path = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("statements_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statement_schemas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    file_id = table.Column<int>(type: "integer", nullable: false),
                    data_id = table.Column<string>(type: "character varying", nullable: true),
                    font_size = table.Column<int>(type: "integer", nullable: true, defaultValue: 14),
                    x = table.Column<decimal>(type: "numeric", nullable: false),
                    y = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("statement_schemas_pkey", x => x.id);
                    table.ForeignKey(
                        name: "statement_schemas_file_id_fkey",
                        column: x => x.file_id,
                        principalTable: "statements",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-1d17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4d37f8e-ef0f-45c6-b6ac-b7a9711cff0b", "AQAAAAIAAYagAAAAEAUHaaK1+TXGKiJpGBAmm6jLw5Xjlp1DPWAQRUar6w2ch9A3Vl2NqQ62zDZjNWT2+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e586",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6f6ee38-9a1d-43b6-a340-04eb5cfcec25", "AQAAAAIAAYagAAAAED5Bkd5FTSzRAimkM+yLStyIcVmmFEF50FM1+0FCa5pnsbIFUO3RRb3n/VOt7HP7Zw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e587",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7ebf1fa-3375-4488-a49d-407872310c69", "AQAAAAIAAYagAAAAENkkg+DIPgDxdMO9/cjYLqPwgW6mUc0T8KIuw0Rl6JXmeQ7wmvpmeFiIYBU+xkZGZA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b18be9c0-aa65-4af8-bd17-10bd9344e588",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ddc8a3ac-b15f-49aa-b8c7-14fa951dbf60", "AQAAAAIAAYagAAAAEBbQPib7oMRuuYBoOtOYhPeE2IfFIpqWzaZRxDEsr3sw6FIQMKedai8ze62OBTXXSg==" });

            migrationBuilder.CreateIndex(
                name: "IX_statement_schemas_file_id",
                table: "statement_schemas",
                column: "file_id");
        }
    }
}
