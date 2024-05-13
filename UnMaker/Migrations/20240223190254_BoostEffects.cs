using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnMaker.Migrations
{
    /// <inheritdoc />
    public partial class BoostEffects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoostEffect",
                table: "Card",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoostEffect",
                table: "Card");
        }
    }
}
