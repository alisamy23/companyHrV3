using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hr");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "bonuss",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bonusValue = table.Column<double>(type: "float", nullable: false),
                    bonusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bonusflag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bonuss", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "hr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.id);
                });

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
                name: "jobs",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    salary = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "religions",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    religionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_religions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vacations",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    vacationCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    path = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    iconId = table.Column<int>(type: "int", nullable: true)
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
                name: "employees",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    deprtmentId = table.Column<int>(type: "int", nullable: false),
                    birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    genderId = table.Column<int>(type: "int", nullable: false),
                    nationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: false),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    religionId = table.Column<int>(type: "int", nullable: false),
                    isAvtive = table.Column<bool>(type: "bit", nullable: true),
                    jobId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_employees_Departments",
                        column: x => x.deprtmentId,
                        principalSchema: "hr",
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_employees_gender",
                        column: x => x.genderId,
                        principalSchema: "hr",
                        principalTable: "gender",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employees_jobs",
                        column: x => x.jobId,
                        principalSchema: "hr",
                        principalTable: "jobs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employees_religions",
                        column: x => x.religionId,
                        principalSchema: "hr",
                        principalTable: "religions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pagesGroups",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pageId = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "employeesBonus",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bonusId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesBonus", x => x.id);
                    table.ForeignKey(
                        name: "FK_employeesBonus_bonuss",
                        column: x => x.bonusId,
                        principalSchema: "hr",
                        principalTable: "bonuss",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employeesBonus_employees",
                        column: x => x.employeeId,
                        principalSchema: "hr",
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employeesVacations",
                schema: "hr",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacationId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    fromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    toDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesVacations", x => x.id);
                    table.ForeignKey(
                        name: "FK_employeesVacations_employees",
                        column: x => x.employeeId,
                        principalSchema: "hr",
                        principalTable: "employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employeesVacations_vacations",
                        column: x => x.vacationId,
                        principalSchema: "hr",
                        principalTable: "vacations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    usetrName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_employees_deprtmentId",
                schema: "hr",
                table: "employees",
                column: "deprtmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_genderId",
                schema: "hr",
                table: "employees",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_jobId",
                schema: "hr",
                table: "employees",
                column: "jobId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_religionId",
                schema: "hr",
                table: "employees",
                column: "religionId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesBonus_bonusId",
                schema: "hr",
                table: "employeesBonus",
                column: "bonusId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesBonus_employeeId",
                schema: "hr",
                table: "employeesBonus",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesVacations_employeeId",
                schema: "hr",
                table: "employeesVacations",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employeesVacations_vacationId",
                schema: "hr",
                table: "employeesVacations",
                column: "vacationId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeesBonus",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "employeesVacations",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "pagesGroups",
                schema: "security");

            migrationBuilder.DropTable(
                name: "users",
                schema: "security");

            migrationBuilder.DropTable(
                name: "bonuss",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "vacations",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "pages",
                schema: "security");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "groups",
                schema: "security");

            migrationBuilder.DropTable(
                name: "icons");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "gender",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "jobs",
                schema: "hr");

            migrationBuilder.DropTable(
                name: "religions",
                schema: "hr");
        }
    }
}
