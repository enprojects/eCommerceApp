using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameCoreReharsearsal.PepoleMigration
{
    public partial class foreign_key_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Person_PersonId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_PersonId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Adresses");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_Adresses_Person",
                table: "Adresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_FK_Adresses_Person",
                table: "Adresses",
                column: "FK_Adresses_Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Person_FK_Adresses_Person",
                table: "Adresses",
                column: "FK_Adresses_Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Person_FK_Adresses_Person",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_FK_Adresses_Person",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "FK_Adresses_Person",
                table: "Adresses");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Adresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_PersonId",
                table: "Adresses",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Person_PersonId",
                table: "Adresses",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
