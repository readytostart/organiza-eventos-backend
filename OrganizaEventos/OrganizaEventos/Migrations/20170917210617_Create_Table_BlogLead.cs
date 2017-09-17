using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizaEventosApi.Migrations
{
    public partial class Create_Table_BlogLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogLead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    IpV4 = table.Column<string>(maxLength: 15, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogLead", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogLead");
        }
    }
}
