using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class AddNewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa26e58-9b8e-4cd7-b6cb-71c1b2fb36a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b00726e3-9ff9-448b-ba0f-ff6a36ab3890");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3af114be-8f82-4752-88af-3d34051bebad", "01de7f98-39f9-4ee3-934b-cdbdee0a5d65", "Administrator", "Administrator" },
                    { "a217c93d-3b8d-4f4d-bbd3-f1b4bb781d91", "3d3fd3bf-c57e-483a-9e77-862f3bf6c6f5", "User", "User" },
                    { "b69d7a8b-94f0-4186-8f22-016f1277a39a", "e2d3fda9-b016-4e90-aa42-02e631c2ef9e", "ProjectManager", "ProjectManager" },
                    { "24399647-63b5-43f6-9d61-63a10fb8ed7a", "61349dbe-0989-4046-8dfc-88ba95070fe5", "HumanResources", "HumanResources" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24399647-63b5-43f6-9d61-63a10fb8ed7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3af114be-8f82-4752-88af-3d34051bebad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a217c93d-3b8d-4f4d-bbd3-f1b4bb781d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b69d7a8b-94f0-4186-8f22-016f1277a39a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fa26e58-9b8e-4cd7-b6cb-71c1b2fb36a9", "f54d403a-a147-46c5-97ce-9656c80b0ce3", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b00726e3-9ff9-448b-ba0f-ff6a36ab3890", "c80bfe47-22c6-474c-ae88-efd589fcdc3b", "User", "User" });
        }
    }
}
