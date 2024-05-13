using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnMaker.Migrations
{
    /// <inheritdoc />
    public partial class BonusAttacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BonusEffects",
                table: "Card",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BonusTitle",
                table: "Card",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BonusValue",
                table: "Card",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusEffects",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "BonusTitle",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "BonusValue",
                table: "Card");
        }
    }
}
