using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _112 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoCV",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoCV",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "AspNetUsers");
        }
    }
}
