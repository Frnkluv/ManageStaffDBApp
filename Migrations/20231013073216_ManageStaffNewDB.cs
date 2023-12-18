using Microsoft.EntityFrameworkCore.Migrations;

namespace ManageStaffDBApp.Migrations
{
    public partial class ManageStaffNewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Departaments_DepartamentId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Positions",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_DepartamentId",
                table: "Positions",
                newName: "IX_Positions_DepartmentId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Positions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Departments_DepartmentId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Positions",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                newName: "IX_Positions_DepartamentId");

            migrationBuilder.AlterColumn<string>(
                name: "Salary",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Departaments_DepartamentId",
                table: "Positions",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
