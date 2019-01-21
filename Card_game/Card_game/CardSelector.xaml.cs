using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Card_game
{
    /// <summary>
    /// Lógica de interacción para CardSelector.xaml
    /// </summary>
    public partial class CardSelector : Window
    {

        public String DeckSelect;
        public CardSelector( string DeckSelect)
        {
            InitializeComponent();
            this.DeckSelect = DeckSelect;
        }

        private void francesa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DeckSelect = "francesa";
            this.Close();
        }

       
        private void española_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DeckSelect = "española";
            this.Close();
        }
    }
}
