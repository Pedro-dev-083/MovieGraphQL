using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieGraphQL.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoriteToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Movies");
        }
    }
}
