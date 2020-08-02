using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameCoreReharsearsal.PepoleMigration
{
    public partial class foreign_key_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddresses_Person_PersonId",
                table: "EmailAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_PersonId",
                table: "EmailAddresses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "EmailAddresses");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_EmailAddresses_Person",
                table: "EmailAddresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_FK_EmailAddresses_Person",
                table: "EmailAddresses",
                column: "FK_EmailAddresses_Person");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_Person_FK_EmailAddresses_Person",
                table: "EmailAddresses",
                column: "FK_EmailAddresses_Person",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddresses_Person_FK_EmailAddresses_Person",
                table: "EmailAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_FK_EmailAddresses_Person",
                table: "EmailAddresses");

            migrationBuilder.DropColumn(
                name: "FK_EmailAddresses_Person",
                table: "EmailAddresses");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "EmailAddresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_PersonId",
                table: "EmailAddresses",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_Person_PersonId",
                table: "EmailAddresses",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
