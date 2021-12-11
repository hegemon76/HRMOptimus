using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMOptimus.Persistance.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ColorLabel",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "LeavesRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "LeavesRegister",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "LeavesRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "InactivatedBy",
                table: "LeavesRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivatedOn",
                table: "LeavesRegister",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "LeavesRegister",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "LeavesRegister",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "LeavesRegister");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "LeavesRegister");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "LeavesRegister");

            migrationBuilder.DropColumn(
                name: "InactivatedBy",
                table: "LeavesRegister");

            migrationBuilder.DropColumn(
                name: "InactivatedOn",
                table: "LeavesRegister");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "LeavesRegister");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "LeavesRegister");

            migrationBuilder.AlterColumn<string>(
                name: "ColorLabel",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

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
    }
}
