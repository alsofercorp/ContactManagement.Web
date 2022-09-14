using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contact.Management.Web.Data.Migrations
{
    public partial class alter_type_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Contacts",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "Contacts",
                type: "int",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);
        }
    }
}
