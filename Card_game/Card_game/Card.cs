using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Card_game.Properties;


namespace Card_game
{
    class Card: Image
    {
        public int Number { get; set; }
        private string State { get; set; }
        public string Type { get; set; }
        public string uri { get; set; }


        public Card(int number, string type,string uri)
        {
            this.Number = number;
            State = "deck";
            this.Type = type;
            this.uri = uri;
            this.Source = new BitmapImage(new Uri(@uri,UriKind.Relative));
            
        }
        
        public bool PlayCard( Card target)
        {
            
            if(target.Number==this.Number || target.Type.Equals(this.Type))
            {
                
                this.State = "played";
                return true;
            }
            
            return false;
    
        }

    }
}
