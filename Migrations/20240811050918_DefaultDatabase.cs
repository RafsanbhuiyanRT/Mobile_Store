using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thanas_Zilas_ZilaId",
                table: "Thanas");

            migrationBuilder.DropForeignKey(
                name: "FK_Zilas_Divisions_DivisionId",
                table: "Zilas");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Zilas_DivisionId",
                table: "Zilas");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Zilas");

            migrationBuilder.AddColumn<int>(
                name: "Division",
                table: "Zilas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ZilaId",
                table: "Thanas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Thanas_Zilas_ZilaId",
                table: "Thanas",
                column: "ZilaId",
                principalTable: "Zilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thanas_Zilas_ZilaId",
                table: "Thanas");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "Zilas");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Zilas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZilaId",
                table: "Thanas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zilas_DivisionId",
                table: "Zilas",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thanas_Zilas_ZilaId",
                table: "Thanas",
                column: "ZilaId",
                principalTable: "Zilas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zilas_Divisions_DivisionId",
                table: "Zilas",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id");
        }
    }
}
