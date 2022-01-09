using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class addIsRemoteWorkToWorkRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30ff9a2d-7f90-4889-a71c-641e3e97fa4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6db8101-03cb-4a1f-9289-7e4d081e0304");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af5f79a0-8373-48cd-b4c3-c0fa8d7c5e0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f61dafe4-35b5-41aa-805e-b7502cb4f74b");

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoteWork",
                table: "WorkRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fa22b017-6519-4a73-8099-dfde84a3d998", "6574f15f-50e2-4b75-a36d-cf6019d1b2e9", "Administrator", "Administrator" },
                    { "12eaab7f-5e8b-46f1-85c0-464afe51013b", "f3877902-300a-4695-b68a-d265d98332ca", "User", "User" },
                    { "7fd914c5-a2fe-419e-a31a-2d7a5223cdac", "baa18503-f56c-46ec-9578-b9a3ce14bf3d", "ProjectManager", "ProjectManager" },
                    { "ba731ab1-1c83-4f4e-b3d5-788dcd364e85", "76ec6f7a-6e5e-486a-97b8-aafa557eac72", "HumanResources", "HumanResources" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12eaab7f-5e8b-46f1-85c0-464afe51013b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fd914c5-a2fe-419e-a31a-2d7a5223cdac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba731ab1-1c83-4f4e-b3d5-788dcd364e85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa22b017-6519-4a73-8099-dfde84a3d998");

            migrationBuilder.DropColumn(
                name: "IsRemoteWork",
                table: "WorkRecords");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f61dafe4-35b5-41aa-805e-b7502cb4f74b", "611442a2-b444-468c-a20f-f972b3bada7c", "Administrator", "Administrator" },
                    { "30ff9a2d-7f90-4889-a71c-641e3e97fa4a", "2c61c78c-4f77-46e8-8c72-55b656290262", "User", "User" },
                    { "af5f79a0-8373-48cd-b4c3-c0fa8d7c5e0f", "7736198e-1467-4d62-aaa2-686479f12c84", "ProjectManager", "ProjectManager" },
                    { "a6db8101-03cb-4a1f-9289-7e4d081e0304", "88c43f78-ba97-4357-a6f1-4ef4a520db0b", "HumanResources", "HumanResources" }
                });
        }
    }
}
