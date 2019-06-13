using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer4.Admin.Data.Mysql.Migrations.EventStore
{
    public partial class UpdateAggregateIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AggregateId",
                table: "StoredEvent",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AggregateId",
                table: "StoredEvent",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
