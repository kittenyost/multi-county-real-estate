using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingCountyLewisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailLeadModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "EmailLeads",
                newName: "SubmittedAt");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EmailLeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "EmailLeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmailLeads");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "EmailLeads");

            migrationBuilder.RenameColumn(
                name: "SubmittedAt",
                table: "EmailLeads",
                newName: "CreatedAt");
        }
    }
}
