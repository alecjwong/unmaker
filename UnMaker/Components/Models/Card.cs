using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnMaker.Components.Models
{
    public enum CardType { Versatile, Attack, Defense, Scheme, Custom }
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [ForeignKey("Deck")]
        public int DeckId { get; set; }
        public string? Title { get; set; }
        [Required]
        public CardType Type { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Value { get; set; }
        public int? Boost { get; set; }
        [Required]
        public int Count { get; set; }
        public string? Effects { get; set; }
        public string? BoostEffect { get; set; }
        public string? CardArtURL { get; set; }
        public string? CardBackURL { get; set; }
        public string? EffectBackgroundPatternURL {  get; set; }
        public string? EffectBackgroundColor { get; set; }
        public string? NameBackgroundPatternURL { get; set; }
        public string? NameBackgroundColor { get; set; }
        public string? BorderColor { get; set; }
        public string? TitleColor { get; set; }
        public string? TitleSize { get; set; }
        public string? TitleFont { get; set; }
        public string? NameColor { get; set; }
        public string? NameSize { get; set; }
        public string? NameFont { get; set; }
        public string? EffectColor { get; set; }
        public string? EffectSize { get; set; }
        public string? EffectFont { get; set; }
        public string? CardImageURL { get; set; }
        public string? BonusTitle { get; set; }
        public int? BonusValue { get; set; }
        public string? BonusEffects { get; set; }
        
        public Card()
        {
            Title = "Title";
            Type = CardType.Versatile;
            Name = "ANY";
            Value = 2;
            Boost = 1;
            Count = 1;
            BorderColor = "#F7EADB";
            EffectBackgroundColor = "#000000";
            NameBackgroundColor = "#000000";
        }
    }
    public class Effect
    {
        public string timing = "";
        public string effect = "";
        public string bonusAttack = "";
        public string moreEffect = "";
    }

    public class CardImage
    {
        public Card card;
        public List<EffectChunk> effects;
        public List<EffectChunk> bonusEffects;
        public IBrowserFile? image;
        public string display;

        //card rendering stuff
        public double EffectBoxHeight = 57.1;
        public double NameBoxHeight = 13;
        public double BoostWidth = 0;
        public double BonusAttackHeight = 0;

        public CardImage()
        {
            card = new Card();
            effects = new List<EffectChunk>();
            bonusEffects = new List<EffectChunk>();
            display = "";
        }
    }

    public class EffectChunk
    {
        public double x;
        public double y;
        public bool timing;
        public bool bonusAttackSymbol;
        public string chunk = "";

        public EffectChunk(double x, double y, bool timing, string chunk)
        {
            this.x = x;
            this.y = y;
            this.timing = timing;
            this.bonusAttackSymbol = false;
            this.chunk = chunk;
        }
        public EffectChunk(double x, double y, bool bonusAttackSymbol)
        {
            this.x = x;
            this.y = y;
            this.timing = false;
            this.bonusAttackSymbol = bonusAttackSymbol;
            this.chunk = "";
        }
    }
}
