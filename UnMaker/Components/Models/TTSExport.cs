using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json;
using UnMaker.Components.Data;
using UnMaker.Components.Models;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace UnMaker.Components.Models
{
    public class TTSExport
    {
        public RootObject Root;
        public static async Task<string> GetJSON(UnMakerContext dbContext, int deckID)
        {
            Deck? deck = await dbContext.Deck.FirstOrDefaultAsync(d => d.DeckId == deckID);

            if (deck != null)
            {
                TTSExport export = new TTSExport();

                List<Card> cards = await dbContext.Card.ToListAsync();
                cards.RemoveAll(m => m.DeckId != deck.DeckId);

                List<HeroCard> heroCards = await dbContext.HeroCard.ToListAsync();
                heroCards.RemoveAll(m => m.DeckId != deck.DeckId);

                List<HeroCard> includedHeroCards = new List<HeroCard>();
                List<int> excludedHeroCards = new List<int>();
                foreach (HeroCard card in heroCards)
                {
                    if (!excludedHeroCards.Contains(card.HeroCardId))
                    {
                        includedHeroCards.Add(card);
                        if (card.BackId != null)
                        {
                            excludedHeroCards.Add(card.BackId.Value);
                        }
                    }
                }

                int objects = 0;
                if (cards.Count > 0) objects++;
                objects += includedHeroCards.Count;

                export.Root.ObjectStates = new ContainedObject[objects];
                for (int i = 0; i < includedHeroCards.Count; i++)
                {
                    export.Root.ObjectStates[i] = new ContainedCustomCard();
                    HeroCard? back = null;
                    if (includedHeroCards[i].BackId != null) back = heroCards.FirstOrDefault(m => m.HeroCardId == includedHeroCards[i].BackId.Value);
                    export.Root.ObjectStates[i].SetHeroCard(includedHeroCards[i], back);
                    export.Root.ObjectStates[i].SetX(-2.5F * (includedHeroCards.Count - i + 1));
                }
                export.Root.ObjectStates[objects - 1] = new ContainedDeck();
                export.Root.ObjectStates[objects - 1].SetDeck(deck, cards);

                return JsonConvert.SerializeObject(export.Root, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }

            return "";
        }

        public TTSExport()
        {
            Root = new RootObject();
        }
    }

    public class RootObject
    {
        public ContainedObject[] ObjectStates { get; set; } = new ContainedObject[0];
    }

    public abstract class ContainedObject
    {
        public string Name = "";
        public Transform Transform = new Transform();
        public string Nickname = "";
        public string Description = "";
        public string GMNotes = "";
        public bool Locked = false;
        public bool Grid = true;
        public bool Snap = true;
        public bool IgnoreFoW = false;
        public bool MeasureMovement = false;
        public bool DragSelectable = true;
        public bool Autoraise = true;
        public bool Sticky = true;
        public bool Tooltip = true;
        public bool GridProjection = false;
        public bool HideWhenFaceDown = true;
        public bool Hands = false;
        public int? CardId;
        public bool SidewaysCard = false;
        public int[]? DeckIDs = null;
        public JObject? CustomDeck = null;
        public string LuaScript = "";
        public string LuaScriptState = "";
        public string XmlUI = "";
        public ContainedObject[]? ContainedObjects = null;

        public void SetX(float x)
        {
            Transform.posX = x;
        }

        public abstract void SetDeck(Deck deck, List<Card> cards);
        public abstract void SetHeroCard(HeroCard card, HeroCard? back);
        public abstract void SetCard(Card card, Deck deck);
    }

    public class ContainedDeck : ContainedObject
    {
        public ContainedDeck() : base()
        {
            Name = "Deck";
        }

        public override void SetDeck(Deck deck, List<Card> cards)
        {
            CustomDeck = new JObject();

            int numCards = 0;
            foreach (Card c in cards)
            {
                numCards += c.Count;
            }
            DeckIDs = new int[numCards];
            ContainedObjects = new ContainedCustomCard[numCards];

            int cardsAdded = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                for(int j = 0; j < cards[i].Count; j++)
                {
                    DeckIDs[cardsAdded] = int.Parse("1" + cards[i].CardId.ToString()) * 100;
                    ContainedObjects[cardsAdded] = new ContainedCustomCard();
                    ContainedObjects[cardsAdded].SetCard(cards[i], deck);
                    cardsAdded++;
                }

                CustomDeck.Add("1" + cards[i].CardId.ToString(), JToken.FromObject(new SingleCard(!String.IsNullOrEmpty(cards[i].CardImageURL) ? Imgur.IdToImage(cards[i].CardImageURL) : "", !String.IsNullOrEmpty(cards[i].CardBackURL) ? Imgur.IdToImage(cards[i].CardBackURL) : !String.IsNullOrEmpty(deck.CardBackImageURL) ? Imgur.IdToImage(deck.CardBackImageURL) : "")));
            }
        }
        public override void SetHeroCard(HeroCard card, HeroCard? back) { }

        public override void SetCard(Card card, Deck deck) { }
    }

    public class ContainedCustomCard : ContainedObject
    {
        public ContainedCustomCard() : base()
        {
            Name = "CardCustom";
            Hands = true;
            CustomDeck = new JObject();
        }

        public override void SetHeroCard(HeroCard card, HeroCard? back)
        {
            Nickname = card.HeroName ?? "";

            Description = card.Ability ?? "";

            CardId = int.Parse("2" + card.HeroCardId.ToString()) * 100;

            string backURL = "http://cloud-3.steamusercontent.com/ugc/1026203121196920886/DF4F3A26991DD9A2C2F58A2E6AA0094AD59F660A/";
            if (back != null) backURL = back.HeroCardImageURL != null ? Imgur.IdToImage(back.HeroCardImageURL) : backURL;
            if(CustomDeck != null) CustomDeck.Add("2" + card.HeroCardId.ToString(), JToken.FromObject(new SingleCard(!String.IsNullOrEmpty(card.HeroCardImageURL) ? Imgur.IdToImage(card.HeroCardImageURL) : "", backURL)));

            Transform.rotz = 0;
        }

        public override void SetCard(Card card, Deck deck)
        {
            Nickname = card.Title ?? "";

            Description = card.Type.ToString();
            if (card.Type != CardType.Scheme) Description += " " + card.Value;
            Description += "\n" + card.Effects;

            CardId = int.Parse("1" + card.CardId.ToString()) * 100;
            if(CustomDeck != null) CustomDeck.Add("1" + card.CardId.ToString(), JToken.FromObject(new SingleCard(!String.IsNullOrEmpty(card.CardImageURL) ? Imgur.IdToImage(card.CardImageURL) : "", !String.IsNullOrEmpty(card.CardBackURL) ? Imgur.IdToImage(card.CardBackURL) : !String.IsNullOrEmpty(deck.CardBackImageURL) ? Imgur.IdToImage(deck.CardBackImageURL) : "")));
        }

        public override void SetDeck(Deck deck, List<Card> cards) { }
    }

    public class Transform
    {
        public float posX = 0.0F;
        public float posY = 0.0F;
        public float posZ = 0.0F;
        public float rotX = 0.0F;
        public float roty = 180.0F;
        public float rotz = 180.0F;
        public float scaleX = 1.0F;
        public float scaleY = 1.0F;
        public float scaleZ = 1.0F;
    }

    public class SingleCard
    {
        public string FaceURL = "";
        public string BackURL = "";
        public int NumWidth = 1;
        public int NumHeight = 1;
        public bool BackIsHidden = true;
        public bool UniqueBack = false;
        public int Type = 0;

        public SingleCard(string FaceURL, string BackURL)
        {
            this.FaceURL = FaceURL;
            this.BackURL = BackURL;
        }
    }
}
