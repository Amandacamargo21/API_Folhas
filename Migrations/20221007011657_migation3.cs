using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FOlhas.Migrations
{
    public partial class migation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salario",
                table: "Funcionarios",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
