using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class PasswordAndEmailChangeLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "NewMail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb20c828-8051-4037-aba5-2d23b84f3852", "fb262957-eff0-48f2-80ee-cd7ae692f8bf", "Administrator", "Administrator" },
                    { "7c93a553-196b-4cf8-8751-ef00654c5a58", "62100c69-73e3-4fb4-a7bf-95b5d35e9a45", "User", "User" },
                    { "375dff43-cdf5-4137-a568-c4edb270081d", "94d25285-3a35-4517-9115-9438a0b4cca8", "ProjectManager", "ProjectManager" },
                    { "302c4d9b-7c8a-494c-b34f-cf73928ee81b", "27234f44-02ea-44f3-adc4-9e905eceb1e7", "HumanResources", "HumanResources" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "302c4d9b-7c8a-494c-b34f-cf73928ee81b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "375dff43-cdf5-4137-a568-c4edb270081d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c93a553-196b-4cf8-8751-ef00654c5a58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb20c828-8051-4037-aba5-2d23b84f3852");

            migrationBuilder.DropColumn(
                name: "NewMail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NewPassword",
                table: "AspNetUsers");

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
    }
}
