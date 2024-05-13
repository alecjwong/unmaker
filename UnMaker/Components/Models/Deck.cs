using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnMaker.Components.Models
{
    public class Deck
    {
        [Key]
        public int DeckId { get; set; }

        [ForeignKey("DeckBuilder")]
        public int DeckBuilderId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        public string? CardBackImageURL { get; set; }
        public string? BackgroundPatternURL { get; set; }
    }
}
