using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Migrations
{
    public partial class CustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "CustomerId", "Email", "FechaCreado", "Identification", "Name", "Phonenumber", "Status", "TypeId" },
                values: new object[] { new Guid("71c87875-4439-4d7c-ba96-f8ba9136d333"), "aagrzada@gmail.com", new DateTime(2023, 4, 1, 10, 1, 40, 971, DateTimeKind.Local).AddTicks(168), "8-873-000", "Alexander Agrazal", "12345", 0, 2 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("71c87875-4439-4d7c-ba96-f8ba9136dbaa"),
                column: "FechaCreado",
                value: new DateTime(2023, 4, 1, 10, 1, 40, 970, DateTimeKind.Local).AddTicks(9096));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: new Guid("71c87875-4439-4d7c-ba96-f8ba9136dbaa"),
                column: "FechaCreado",
                value: new DateTime(2023, 3, 31, 23, 34, 53, 385, DateTimeKind.Local).AddTicks(9261));
        }
    }
}
