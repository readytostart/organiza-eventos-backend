using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrganizaEventosApi.Migrations
{
    public partial class Change_table_MobLeeLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogLead");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.CreateTable(
                name: "MobLeeLead",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    IpV4 = table.Column<string>(maxLength: 15, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobLeeLead", x => x.Email);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobLeeLead_Email",
                table: "MobLeeLead",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobLeeLead");

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

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    IpV4 = table.Column<string>(maxLength: 15, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogLead_Email",
                table: "BlogLead",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lead_Email",
                table: "Lead",
                column: "Email",
                unique: true);
        }
    }
}
