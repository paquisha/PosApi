using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirtsName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    LastName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    AuditCreateUser = table.Column<int>(type: "int", nullable: false),
                    AuditCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUpdateUser = table.Column<int>(type: "int", nullable: true),
                    AuditUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditDeleteUser = table.Column<int>(type: "int", nullable: true),
                    AuditDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK__UserRoles__RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK__UserRoles__UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
