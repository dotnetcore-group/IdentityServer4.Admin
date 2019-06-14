using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer4.Admin.Data.Mysql.Migrations.IdentityServer
{
    public partial class AddUserLoginLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoginLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Uid = table.Column<long>(nullable: false),
                    Browser = table.Column<string>(nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    OS = table.Column<string>(maxLength: 50, nullable: true),
                    Device = table.Column<string>(maxLength: 50, nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginLogs_Uid",
                table: "UserLoginLogs",
                column: "Uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoginLogs");
        }
    }
}
