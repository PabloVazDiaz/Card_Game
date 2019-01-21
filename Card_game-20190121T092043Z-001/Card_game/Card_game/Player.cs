using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Card_game
{
    class Player
    {
        private string name { get; set; }
        public List<Card> hand { get; set; }
        public bool active { get; set; }
        public Grid HandArea { get; set; }
        public Label PlayerLabel { get; set; }

        public Player(string name, Deck playDeck, bool active, Grid handArea, Label label)
        {
            this.name = name;
            hand = new List<Card>();
            this.active = active;
            HandArea = handArea;
            this.PlayerLabel = label;
            this.DrawCard(playDeck, 3);
        }

        public void DrawCard(Deck deck, int amount)
        {
            for(int i=0; i < amount; i++)
            {
                hand.Add(deck.CardDraw());
                HandArea.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetColumn(hand.Last(), hand.Count-1);
                HandArea.Children.Add(hand.Last());
                

            }
            
        }

        public void NextPlayer(List<Player> players)
        {
            int cont =players.FindIndex(x=> x.name.Equals(this.name));
            players[cont].active = false;
            players[cont].PlayerLabel.Visibility = Visibility.Hidden;

            if(cont+1 < players.Count)
            {
                players[cont + 1].active = true;
                players[cont + 1].PlayerLabel.Visibility = Visibility.Visible;
            }
            else
            {
                players[0].active = true;
                players[0].PlayerLabel.Visibility = Visibility.Visible;
            }
           
        }

        public void Win()
        {
            MessageBox.Show($"GANADOR:{name}!!!");
        }

    }
}
