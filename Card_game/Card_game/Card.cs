using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Card_game
{
    class Card: Image
    {
        private int Number { get; set; }
        private string State { get; set; }
        private string Type { get; set; }
        private string Source { get; set; }


        public Card(int number, string type, string source)
        {
            this.Number = number;
            State = "deck";
            this.Type = type;
            this.Source = source;
            
        }

        public Card PlayCard( Card target)
        {
            
            if(target.Number==this.Number || target.Type.Equals(this.Type))
            {
                
                this.State = "played";
                
            }
            
            return this;
    
        }
    }
}
