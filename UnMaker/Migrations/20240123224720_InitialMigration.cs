using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnMaker.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: true),
                    Boost = table.Column<int>(type: "INTEGER", nullable: true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Effects = table.Column<string>(type: "TEXT", nullable: true),
                    CardArtURL = table.Column<string>(type: "TEXT", nullable: true),
                    CardBackURL = table.Column<string>(type: "TEXT", nullable: true),
                    EffectBackgroundPatternURL = table.Column<string>(type: "TEXT", nullable: true),
                    EffectBackgroundColor = table.Column<string>(type: "TEXT", nullable: true),
                    NameBackgroundPatternURL = table.Column<string>(type: "TEXT", nullable: true),
                    NameBackgroundColor = table.Column<string>(type: "TEXT", nullable: true),
                    BorderColor = table.Column<string>(type: "TEXT", nullable: true),
                    TitleColor = table.Column<string>(type: "TEXT", nullable: true),
                    TitleSize = table.Column<string>(type: "TEXT", nullable: true),
                    TitleFont = table.Column<string>(type: "TEXT", nullable: true),
                    NameColor = table.Column<string>(type: "TEXT", nullable: true),
                    NameSize = table.Column<string>(type: "TEXT", nullable: true),
                    NameFont = table.Column<string>(type: "TEXT", nullable: true),
                    EffectColor = table.Column<string>(type: "TEXT", nullable: true),
                    EffectSize = table.Column<string>(type: "TEXT", nullable: true),
                    EffectFont = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeckBuilderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CardBackImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    BackgroundPatternURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.DeckId);
                });

            migrationBuilder.CreateTable(
                name: "HeroCard",
                columns: table => new
                {
                    HeroCardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeckId = table.Column<int>(type: "INTEGER", nullable: false),
                    Move = table.Column<int>(type: "INTEGER", nullable: false),
                    HeroName = table.Column<string>(type: "TEXT", nullable: true),
                    HeroHealth = table.Column<int>(type: "INTEGER", nullable: false),
                    HeroRange = table.Column<int>(type: "INTEGER", nullable: false),
                    SidekickName = table.Column<string>(type: "TEXT", nullable: true),
                    SidekickHealth = table.Column<int>(type: "INTEGER", nullable: false),
                    SidekickRange = table.Column<int>(type: "INTEGER", nullable: false),
                    NumSidekicks = table.Column<int>(type: "INTEGER", nullable: false),
                    Ability = table.Column<string>(type: "TEXT", nullable: true),
                    Quote = table.Column<string>(type: "TEXT", nullable: true),
                    TopBackgroundPatternURL = table.Column<string>(type: "TEXT", nullable: true),
                    TopBackgroundColor = table.Column<string>(type: "TEXT", nullable: true),
                    BottomBackgroundPatternURL = table.Column<string>(type: "TEXT", nullable: true),
                    BottomBackgroundColor = table.Column<string>(type: "TEXT", nullable: true),
                    NameColor = table.Column<string>(type: "TEXT", nullable: true),
                    NameFont = table.Column<string>(type: "TEXT", nullable: true),
                    NameSize = table.Column<string>(type: "TEXT", nullable: true),
                    AbilityColor = table.Column<string>(type: "TEXT", nullable: true),
                    AbilityFont = table.Column<string>(type: "TEXT", nullable: true),
                    AbilitySize = table.Column<string>(type: "TEXT", nullable: true),
                    QuoteColor = table.Column<string>(type: "TEXT", nullable: true),
                    QuoteFont = table.Column<string>(type: "TEXT", nullable: true),
                    QuoteSize = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroCard", x => x.HeroCardId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "HeroCard");
        }
    }
}
