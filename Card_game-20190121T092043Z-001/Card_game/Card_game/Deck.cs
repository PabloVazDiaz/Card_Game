using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;


namespace Card_game
{
    class Deck: Image
    {
        private List<Card> InitialCards { get; set; }
        private List<Card> Cards { get; set; }
        private int Players { get; set; }
        private string Name { get; set; }
        private Random rd = new Random();

        public Deck( string jsonPath, List<Card> InitialCards, int players, string name)
        {
            //InitialCards = createCards(jsonPath);
            this.InitialCards = InitialCards;
            Cards = new List<Card>();
            Cards.AddRange(InitialCards);
            Players = players;
            Name = name;
            this.Source= new BitmapImage(new Uri("Assets/Deck/gray_back.png", UriKind.Relative));
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

        public void shuffle()
        {
            Cards = Cards.OrderBy(x => rd.Next()).ToList();
        }

        public void ResetDeck()
        {
            Cards.AddRange(InitialCards);
        }
    }
}
