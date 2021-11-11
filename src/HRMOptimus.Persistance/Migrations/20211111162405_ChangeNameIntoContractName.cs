using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class ChangeNameIntoContractName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contracts",
                newName: "ContractName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContractName",
                table: "Contracts",
                newName: "Name");
        }
    }
}
