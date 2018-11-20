using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_game
{
    class Player
    {
        private string name { get; set; }
        private List<Card> hand { get; set; }
        private bool active { get; set; }


        public void DrawCard(Deck deck, int amount)
        {
            for(int i=0; i < amount; i++)
            {
                hand.Add(deck.CardDraw());
            }
            
        }

        public void NextPlayer(List<Player> players)
        {
            int cont =players.FindIndex(x=> x.name.Equals(this.name));
            players[cont].active = false;
            players[cont+1].active = true;
        }

    }
}
