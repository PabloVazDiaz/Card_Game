using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Card_game
{
    class Card
    {
        private int number { get; set; }
        private string state { get; set; }
        private string type { get; set; }
        private Image img { get; set; }


        public Card(int number, string type, Image img)
        {
            this.number = number;
            state = "deck";
            this.type = type;
            this.img = img;
        }

        public Card PlayCard()
        {


            return this;
    
        }
    }
}
