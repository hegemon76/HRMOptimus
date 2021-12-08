using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fa26e58-9b8e-4cd7-b6cb-71c1b2fb36a9", "f54d403a-a147-46c5-97ce-9656c80b0ce3", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b00726e3-9ff9-448b-ba0f-ff6a36ab3890", "c80bfe47-22c6-474c-ae88-efd589fcdc3b", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa26e58-9b8e-4cd7-b6cb-71c1b2fb36a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b00726e3-9ff9-448b-ba0f-ff6a36ab3890");
        }
    }
}
