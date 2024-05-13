using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnMaker.Components.Models
{
    public enum Range { Melee, Ranged, Reach, None }
    public class HeroCard
    {
        [Key]
        public int HeroCardId { get; set; }
        [ForeignKey("Deck")]
        public int DeckId { get; set; }
        public int Move { get; set; }
        public string? HeroName { get; set; }
        public int HeroHealth { get; set; }
        public Range HeroRange { get; set; }
        public string? SidekickName { get; set; }
        public int SidekickHealth { get; set; }
        public Range SidekickRange { get; set; }
        public int NumSidekicks { get; set; }
        public string? Ability { get; set; }
        public string? Quote { get; set; }
        public string? TopBackgroundPatternURL { get; set; }
        public string? TopBackgroundColor { get; set; }
        public string? BottomBackgroundPatternURL { get; set; }
        public string? BottomBackgroundColor { get; set; }
        public string? NameColor { get; set; }
        public string? NameFont { get; set; }
        public string? NameSize { get; set; }
        public string? AbilityColor { get; set; }
        public string? AbilityFont { get; set; }
        public string? AbilitySize { get; set; }
        public string? QuoteColor { get; set; }
        public string? QuoteFont { get; set; }
        public string? QuoteSize { get; set; }
        public string? BorderColor {  get; set; }
        public string? HealthColor {  get; set; }
        public string? HeroCardImageURL { get; set; }
        public int? BackId { get; set; }

        public HeroCard()
        {
            this.Move = 2;
            this.HeroName = "Hero";
            this.HeroHealth = 15;
            this.HeroRange = Models.Range.Melee;
            this.SidekickName = "Sidekick";
            this.SidekickHealth = 6;
            this.SidekickRange = Models.Range.Melee;
            this.NumSidekicks = 1;
            this.Ability = "";
            this.Quote = "";
            this.TopBackgroundColor = "#1791BA";
            this.BottomBackgroundColor = "#000000";
            this.AbilityColor = "#000000";
            this.BorderColor = "#F7EADB";
            this.HealthColor = "#8BC8DD";
        }
    }
    public class HeroCardImage
    {
        public HeroCard heroCard;
        public List<AbilityChunk> ability;
        public List<AbilityChunk> quote;

        public HeroCardImage()
        {
            heroCard = new HeroCard();
            ability = new List<AbilityChunk>();
            quote = new List<AbilityChunk>();
        }
    }

    public class AbilityChunk
    {
        public readonly static double lineWidth = 80;
        public readonly static double lineHeight = 7.5;

        public double x;
        public double y;
        public string chunk = "";

        public AbilityChunk(double x, double y, string chunk)
        {
            this.x = x;
            this.y = y;
            this.chunk = chunk;
        }
    }
}
