using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Income_Calculator.Migrations
{
    public partial class Refactorythedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Money",
                table: "Incomes",
                newName: "Total");

            migrationBuilder.CreateTable(
                name: "Registry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Money = table.Column<double>(type: "float", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registry_Incomes_BankId",
                        column: x => x.BankId,
                        principalTable: "Incomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registry_BankId",
                table: "Registry",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registry");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Incomes",
                newName: "Money");
        }
    }
}
