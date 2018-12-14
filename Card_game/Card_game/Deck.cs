using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Card_game
{
    class Deck
    {
        public Deck( string jsonPath, List<Card> initialCards, List<Card> cards, int players, string name)
        {
            InitialCards = createCards(jsonPath);
            InitialCards = initialCards;
            Cards = cards;
            Players = players;
            Name = name;
        }

        private List<Card> createCards(string jsonPath)
        {

            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                InitialCards = JsonConvert.DeserializeObject<List<Card>>(json);
            }
 

            return InitialCards;
        }

        private List<Card> InitialCards { get; set; }
        private List<Card> Cards { get; set; }
        private int Players { get; set; }
        private string Name { get; set; }

       



        public Card CardDraw()
        {
            Card selectedCard = Cards.Last();
            Cards.Remove(selectedCard);
            if (Cards.Count == 0)
            {
                ResetDeck();
            }
            return selectedCard;
        }

        public void ResetDeck()
        {
            Cards.AddRange(InitialCards);
        }
    }
}
