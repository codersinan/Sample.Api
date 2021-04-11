using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Api.Migrations
{
    public partial class RemovedTagsAuditableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tags",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Tags",
                type: "TEXT",
                nullable: true);
        }
    }
}
