using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesPage_AspNetRoles_roleID",
                table: "RolesPage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolesPage",
                table: "RolesPage");

            migrationBuilder.RenameTable(
                name: "RolesPage",
                newName: "RolesPages");

            migrationBuilder.RenameIndex(
                name: "IX_RolesPage_roleID",
                table: "RolesPages",
                newName: "IX_RolesPages_roleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolesPages",
                table: "RolesPages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentiD = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<int>(type: "int", nullable: false),
                    pAgeRout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolesPages_PageId",
                table: "RolesPages",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPages_AspNetRoles_roleID",
                table: "RolesPages",
                column: "roleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPages_Pages_PageId",
                table: "RolesPages",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesPages_AspNetRoles_roleID",
                table: "RolesPages");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesPages_Pages_PageId",
                table: "RolesPages");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolesPages",
                table: "RolesPages");

            migrationBuilder.DropIndex(
                name: "IX_RolesPages_PageId",
                table: "RolesPages");

            migrationBuilder.RenameTable(
                name: "RolesPages",
                newName: "RolesPage");

            migrationBuilder.RenameIndex(
                name: "IX_RolesPages_roleID",
                table: "RolesPage",
                newName: "IX_RolesPage_roleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolesPage",
                table: "RolesPage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolesPage_AspNetRoles_roleID",
                table: "RolesPage",
                column: "roleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
