using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAgree",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoCV",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RolesPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesPage_AspNetRoles_roleID",
                        column: x => x.roleID,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolesPage_roleID",
                table: "RolesPage",
                column: "roleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesPage");

            migrationBuilder.AddColumn<bool>(
                name: "IsAgree",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
