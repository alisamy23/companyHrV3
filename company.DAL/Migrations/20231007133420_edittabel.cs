using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class edittabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pagesGroups",
                schema: "security");

            migrationBuilder.DropTable(
                name: "users",
                schema: "security");

            migrationBuilder.DropTable(
                name: "pages",
                schema: "security");

            migrationBuilder.DropTable(
                name: "groups",
                schema: "security");

            migrationBuilder.DropTable(
                name: "icons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "groups",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "icons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iconCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_icons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    usetrName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_employees",
                        column: x => x.id,
                        principalSchema: "hr",
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_users_groups",
                        column: x => x.groupId,
                        principalSchema: "security",
                        principalTable: "groups",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pages",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iconId = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    pageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    path = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                    table.ForeignKey(
                        name: "FK_pages_icons",
                        column: x => x.iconId,
                        principalTable: "icons",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pages_pages",
                        column: x => x.parentId,
                        principalSchema: "security",
                        principalTable: "pages",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pagesGroups",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    pageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagesGroups", x => x.id);
                    table.ForeignKey(
                        name: "FK_pagesGroups_groups",
                        column: x => x.groupId,
                        principalSchema: "security",
                        principalTable: "groups",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pagesGroups_pages",
                        column: x => x.pageId,
                        principalSchema: "security",
                        principalTable: "pages",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pages_iconId",
                schema: "security",
                table: "pages",
                column: "iconId");

            migrationBuilder.CreateIndex(
                name: "IX_pages_parentId",
                schema: "security",
                table: "pages",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_pagesGroups_groupId",
                schema: "security",
                table: "pagesGroups",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_pagesGroups_pageId",
                schema: "security",
                table: "pagesGroups",
                column: "pageId");

            migrationBuilder.CreateIndex(
                name: "IX_users_groupId",
                schema: "security",
                table: "users",
                column: "groupId");
        }
    }
}
