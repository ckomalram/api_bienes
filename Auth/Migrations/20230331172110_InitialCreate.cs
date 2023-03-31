using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Email", "FechaCreado", "IdType", "Identification", "Name", "Phonenumber", "Status" },
                values: new object[,]
                {
                    { new Guid("71c87875-4439-4d7c-ba96-f8ba9136dba2"), "aagrzada@gmail.com", new DateTime(2023, 3, 31, 12, 21, 10, 731, DateTimeKind.Local).AddTicks(6397), 0, "8-873-000", "Alexander Agrazal", "12345", 0 },
                    { new Guid("71c87875-4439-4d7c-ba96-f8ba9136dba3"), "hdegracia@gmail.com", new DateTime(2023, 3, 31, 12, 21, 10, 731, DateTimeKind.Local).AddTicks(6403), 0, "8-000-387", "Hector De Gracia", "12345", 0 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "FechaCreado", "IdType", "Identification", "Name", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("71c87875-4439-4d7c-ba96-f8ba9136dba1"), "yoainaris@gmail.com", new DateTime(2023, 3, 31, 12, 21, 10, 731, DateTimeKind.Local).AddTicks(5292), 0, "8-920-953", "Yoainaris Concepcion", "12345", 0, 0 },
                    { new Guid("71c87875-4439-4d7c-ba96-f8ba9136dbaa"), "ckomalram@gmail.com", new DateTime(2023, 3, 31, 12, 21, 10, 731, DateTimeKind.Local).AddTicks(5272), 0, "8-873-387", "Carlyle Komalram", "12345", 0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
