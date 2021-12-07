using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class ChangeLeaveRegisterProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "LeavesRegister");

            migrationBuilder.AlterColumn<int>(
                name: "IsApproved",
                table: "LeavesRegister",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractId",
                table: "Employees",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContractId",
                table: "Employees");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "LeavesRegister",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "LeavesRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContractId",
                table: "Employees",
                column: "ContractId",
                unique: true);
        }
    }
}
