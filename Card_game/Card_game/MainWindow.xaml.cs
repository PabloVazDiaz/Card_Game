using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Card_game
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool MouseIsDown;
        Point initial;
        Image imagemoving;
        Point boundary;
        Point initialMouse;
        Deck playDeck;
        Card activeCard;
        int handSize=0;
        List<Card> toSerialize = new List<Card>();


        public MainWindow()
        {
            InitializeComponent();

            Dictionary<int, string> typeDic = new Dictionary<int, string>()
            {
                { 0,"Hearts"},
                {1,"Diamonds" },
                {2,"Clubs" },
                {3,"Spikes" }
            };

            

            for (int i = 0; i < 4; i++)
            {
                string type = typeDic[i];
                for (int j = 1; j < 14; j++)
                {
                    int number = j;
                    string source = $"Assets/Deck/{j}{(typeDic[i] as string).ToUpper()[0]}.png";
                    Card c = new Card(number, type, source);
                    c.MouseDown += Image_MouseDown;
                    c.MouseUp += Image_MouseUp;
                    toSerialize.Add(c);
                }
            }
            /*
            MessageBox.Show("Json creado");
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("cartasJson.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {

                serializer.Serialize(writer, toSerialize);
            }
            /*
            canvasTotal.Children.Add(cartaPrueba);
            Canvas.SetTop(cartaPrueba, 2);
            Canvas.SetLeft(cartaPrueba, 2);
            */
        }

        

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            MouseIsDown = false;
            Point mouse = Mouse.GetPosition(Application.Current.MainWindow);
            if (mouse.X > boundary.X && mouse.Y >boundary.Y && mouse.X < boundary.X+PlayArea.Width && mouse.Y<PlayArea.Height+boundary.Y)
            {
                if((sender as Card).PlayCard(activeCard))
                {
                    
                    PlayArea.Children.Remove(activeCard);
                    activeCard = sender as Card;
                    Player1_Hand.Children.Remove(activeCard);
                    //Grid.SetColumn(activeCard, 0);
                    PlayArea.Children.Add(activeCard);
                }
                else
                {
                    imagemoving.RenderTransform = new TranslateTransform { X = initial.X, Y = initial.Y };

                }
            }
            else
            {
                imagemoving.RenderTransform = new TranslateTransform { X = initial.X , Y = initial.Y };
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            MouseIsDown = true;
            initialMouse= e.GetPosition(canvasTotal);
            imagemoving = (sender as Image);
            //initial = new Point( Canvas.GetLeft(sender as Image), Canvas.GetTop(sender as Image));
            (sender as Image).TranslatePoint(initial,canvasTotal);
        }


        private void CanvasTotal_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {

                Point p = Mouse.GetPosition(canvasTotal);
                double xOffset = p.X - initialMouse.X;
                double yOffset = p.Y - initialMouse.Y;
                imagemoving.RenderTransform = new TranslateTransform { X = xOffset, Y = yOffset };
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            playDeck = new Deck("cartasJson.json", toSerialize, 2, "Baraja");
            DeckArea.Children.Add(playDeck);
            playDeck.shuffle();
            playDeck.MouseDown += PlayDeck_MouseDown;
            boundary = new Point(Canvas.GetLeft(PlayArea), Canvas.GetTop(PlayArea));
            activeCard = playDeck.CardDraw();
            Grid.SetColumn(activeCard, 0);
            PlayArea.Children.Add(activeCard);
        }

        private void PlayDeck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Card c = (sender as Deck).CardDraw();
            Player1_Hand.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(c, handSize);
            Player1_Hand.Children.Add(c);
            handSize++;
        }

 
    }
}
