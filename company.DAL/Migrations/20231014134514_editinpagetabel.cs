using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class editinpagetabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pAgeRout",
                table: "Pages");

            migrationBuilder.AlterColumn<string>(
                name: "PageName",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PageAction",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageControl",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageAction",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageControl",
                table: "Pages");

            migrationBuilder.AlterColumn<int>(
                name: "PageName",
                table: "Pages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "pAgeRout",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
