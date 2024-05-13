using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnMaker.Migrations
{
    /// <inheritdoc />
    public partial class StoreCardImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroCardImageURL",
                table: "HeroCard",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardImageURL",
                table: "Card",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroCardImageURL",
                table: "HeroCard");

            migrationBuilder.DropColumn(
                name: "CardImageURL",
                table: "Card");
        }
    }
}
