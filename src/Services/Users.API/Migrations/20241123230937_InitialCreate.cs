using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_PERMISSIONS",
                columns: table => new
                {
                    ID_PERMISSION = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_CODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_CREATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TX_LAST_UPDATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PERMISSIONS", x => x.ID_PERMISSION);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USERS",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_CREATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TX_LAST_UPDATE = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USERS", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USERS_PERMISSIONS",
                columns: table => new
                {
                    ID_USER_PERMISSION = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_USER_FK = table.Column<int>(type: "int", nullable: false),
                    TX_PERMISSION_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USERS_PERMISSIONS", x => x.ID_USER_PERMISSION);
                    table.ForeignKey(
                        name: "FK_TBL_USERS_PERMISSIONS_TBL_PERMISSIONS_TX_PERMISSION_FK",
                        column: x => x.TX_PERMISSION_FK,
                        principalTable: "TBL_PERMISSIONS",
                        principalColumn: "ID_PERMISSION",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_USERS_PERMISSIONS_TBL_USERS_TX_PERMISSION_FK",
                        column: x => x.TX_PERMISSION_FK,
                        principalTable: "TBL_USERS",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USERS_PERMISSIONS_TX_PERMISSION_FK",
                table: "TBL_USERS_PERMISSIONS",
                column: "TX_PERMISSION_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_USERS_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "TBL_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "TBL_USERS");
        }
    }
}
