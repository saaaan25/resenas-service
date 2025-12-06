using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reseñas.Migrations
{
    /// <inheritdoc />
    public partial class ValidacionOrden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_usuario",
                table: "Resenas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_usuario",
                table: "Resenas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_usuario",
                table: "Resenas");

            migrationBuilder.DropColumn(
                name: "Nombre_usuario",
                table: "Resenas");
        }
    }
}
