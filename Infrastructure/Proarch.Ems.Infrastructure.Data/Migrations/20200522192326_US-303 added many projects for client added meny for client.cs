using Microsoft.EntityFrameworkCore.Migrations;

namespace Proarch.Ems.Infrastructure.Data.Migrations
{
    public partial class US303addedmanyprojectsforclientaddedmenyforclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeProject",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmployeeProject",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "longtext CHARACTER SET utf8",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Projects",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Projects",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                table: "Employees",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "longtext CHARACTER SET utf8",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "longtext CHARACTER SET utf8",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Employees",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "EmployeeProject",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "EmployeeProject",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Clients",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                type: "longtext CHARACTER SET utf8",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
