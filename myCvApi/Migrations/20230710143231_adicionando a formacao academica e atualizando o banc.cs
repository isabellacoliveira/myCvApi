using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myCvApi.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoaformacaoacademicaeatualizandoobanc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeJson",
                table: "Formacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GradeJson",
                table: "Formacoes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
