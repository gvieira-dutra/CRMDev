using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRMDev.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactOpportunityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_ContactId",
                table: "Opportunities",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Contacts_ContactId",
                table: "Opportunities",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Contacts_ContactId",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_ContactId",
                table: "Opportunities");
        }
    }
}
