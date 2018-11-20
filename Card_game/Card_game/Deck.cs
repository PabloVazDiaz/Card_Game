using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    class Deck
    {
        public Deck(List<Card> initialCards, List<Card> cards, int players, string name)
        {
            InitialCards = initialCards;
            Cards = cards;
            Players = players;
            Name = name;
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
