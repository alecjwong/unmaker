using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnMaker.Migrations
{
    /// <inheritdoc />
    public partial class HeroCardBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BackId",
                table: "HeroCard",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackId",
                table: "HeroCard");
        }
    }
}
