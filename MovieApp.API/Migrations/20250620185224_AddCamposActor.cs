using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Actors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Actors");
        }
    }
}
