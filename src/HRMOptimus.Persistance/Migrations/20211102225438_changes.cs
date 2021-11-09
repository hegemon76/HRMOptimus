using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkRecords_DayWorks_DayWorkId",
                table: "WorkRecords");

            migrationBuilder.DropTable(
                name: "DayWorks");

            migrationBuilder.DropTable(
                name: "EmployeeMonthWork");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "MonthWorks");

            migrationBuilder.DropIndex(
                name: "IX_WorkRecords_DayWorkId",
                table: "WorkRecords");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DayWorkId",
                table: "WorkRecords");

            migrationBuilder.DropColumn(
                name: "User",
                table: "WorkRecords");

            migrationBuilder.DropColumn(
                name: "WorkStartOn",
                table: "WorkRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "WorkedHours",
                table: "WorkRecords",
                newName: "WorkStart");

            migrationBuilder.RenameColumn(
                name: "WorkStopOn",
                table: "WorkRecords",
                newName: "WorkEnd");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Employees",
                newName: "LeaveDaysLeft");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Employees",
                newName: "BirthDate");

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "WorkRecords",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkingTime",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "WorkTime",
                table: "Contracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "LeaveDays",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Payment",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeavesRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavesRegister", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeavesRegister_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractId",
                table: "Employees",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeavesRegister_EmployeeId",
                table: "LeavesRegister",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeavesRegister");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "WorkRecords");

            migrationBuilder.DropColumn(
                name: "WorkingTime",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeaveDays",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "WorkStart",
                table: "WorkRecords",
                newName: "WorkedHours");

            migrationBuilder.RenameColumn(
                name: "WorkEnd",
                table: "WorkRecords",
                newName: "WorkStopOn");

            migrationBuilder.RenameColumn(
                name: "LeaveDaysLeft",
                table: "Employees",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Employees",
                newName: "DateOfBirth");

            migrationBuilder.AddColumn<int>(
                name: "DayWorkId",
                table: "WorkRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "WorkRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkStartOn",
                table: "WorkRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WorkTime",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MonthWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOff = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InactivatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingMonthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayWorks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayWorks_MonthWorks_WorkingMonthId",
                        column: x => x.WorkingMonthId,
                        principalTable: "MonthWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMonthWork",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    MonthWorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMonthWork", x => new { x.EmployeesId, x.MonthWorksId });
                    table.ForeignKey(
                        name: "FK_EmployeeMonthWork_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMonthWork_MonthWorks_MonthWorksId",
                        column: x => x.MonthWorksId,
                        principalTable: "MonthWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkRecords_DayWorkId",
                table: "WorkRecords",
                column: "DayWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractId",
                table: "Employees",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DayWorks_EmployeeId",
                table: "DayWorks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DayWorks_WorkingMonthId",
                table: "DayWorks",
                column: "WorkingMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMonthWork_MonthWorksId",
                table: "EmployeeMonthWork",
                column: "MonthWorksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkRecords_DayWorks_DayWorkId",
                table: "WorkRecords",
                column: "DayWorkId",
                principalTable: "DayWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
