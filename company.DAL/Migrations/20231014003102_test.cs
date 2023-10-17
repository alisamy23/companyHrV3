using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_Departments",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_gender",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_jobs",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_religions",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesBonus_bonuss",
                schema: "hr",
                table: "employeesBonus");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesBonus_employees",
                schema: "hr",
                table: "employeesBonus");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesVacations_employees",
                schema: "hr",
                table: "employeesVacations");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesVacations_vacations",
                schema: "hr",
                table: "employeesVacations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                schema: "hr",
                table: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                schema: "hr",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_Departments_deprtmentId",
                schema: "hr",
                table: "employees",
                column: "deprtmentId",
                principalSchema: "hr",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_gender_genderId",
                schema: "hr",
                table: "employees",
                column: "genderId",
                principalSchema: "hr",
                principalTable: "gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employees_jobs_jobId",
                schema: "hr",
                table: "employees",
                column: "jobId",
                principalSchema: "hr",
                principalTable: "jobs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_religions_religionId",
                schema: "hr",
                table: "employees",
                column: "religionId",
                principalSchema: "hr",
                principalTable: "religions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeesBonus_bonuss_bonusId",
                schema: "hr",
                table: "employeesBonus",
                column: "bonusId",
                principalSchema: "hr",
                principalTable: "bonuss",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeesBonus_employees_employeeId",
                schema: "hr",
                table: "employeesBonus",
                column: "employeeId",
                principalSchema: "hr",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeesVacations_employees_employeeId",
                schema: "hr",
                table: "employeesVacations",
                column: "employeeId",
                principalSchema: "hr",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employeesVacations_vacations_vacationId",
                schema: "hr",
                table: "employeesVacations",
                column: "vacationId",
                principalSchema: "hr",
                principalTable: "vacations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_Departments_deprtmentId",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_gender_genderId",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_jobs_jobId",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_religions_religionId",
                schema: "hr",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesBonus_bonuss_bonusId",
                schema: "hr",
                table: "employeesBonus");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesBonus_employees_employeeId",
                schema: "hr",
                table: "employeesBonus");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesVacations_employees_employeeId",
                schema: "hr",
                table: "employeesVacations");

            migrationBuilder.DropForeignKey(
                name: "FK_employeesVacations_vacations_vacationId",
                schema: "hr",
                table: "employeesVacations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                schema: "hr",
                table: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                schema: "hr",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_Departments",
                schema: "hr",
                table: "employees",
                column: "deprtmentId",
                principalSchema: "hr",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_gender",
                schema: "hr",
                table: "employees",
                column: "genderId",
                principalSchema: "hr",
                principalTable: "gender",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_jobs",
                schema: "hr",
                table: "employees",
                column: "jobId",
                principalSchema: "hr",
                principalTable: "jobs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_religions",
                schema: "hr",
                table: "employees",
                column: "religionId",
                principalSchema: "hr",
                principalTable: "religions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesBonus_bonuss",
                schema: "hr",
                table: "employeesBonus",
                column: "bonusId",
                principalSchema: "hr",
                principalTable: "bonuss",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesBonus_employees",
                schema: "hr",
                table: "employeesBonus",
                column: "employeeId",
                principalSchema: "hr",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesVacations_employees",
                schema: "hr",
                table: "employeesVacations",
                column: "employeeId",
                principalSchema: "hr",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesVacations_vacations",
                schema: "hr",
                table: "employeesVacations",
                column: "vacationId",
                principalSchema: "hr",
                principalTable: "vacations",
                principalColumn: "id");
        }
    }
}
