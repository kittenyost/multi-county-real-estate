using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivingCountyLewisAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageToEmailLead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admins",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Admins",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "EmailLeads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "EmailLeads");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Admins",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "Email");
        }
    }
}
