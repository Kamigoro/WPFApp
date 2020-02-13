using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTestWPF.Migrations
{
    public partial class ChangingEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "People",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "People",
                newName: "email");
        }
    }
}
