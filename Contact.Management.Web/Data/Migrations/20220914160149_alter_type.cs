using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contact.Management.Web.Data.Migrations
{
    public partial class alter_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "Contacts",
                type: "int",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Contact",
                table: "Contacts",
                type: "bigint",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 9);
        }
    }
}
