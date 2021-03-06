﻿using Newtonsoft.Json;
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
        public String DeckSelect;
        bool MouseIsDown;
        Point initial;
        Image imagemoving;
        Point boundary;
        Point initialMouse;
        Deck playDeck;
        Card activeCard;
        List<Card> toSerialize = new List<Card>();
        List<Card> Player1Hand = new List<Card>();
        List<Player> Players = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();

            CardSelector cs = new CardSelector(DeckSelect);
            cs.ShowDialog();
            this.DeckSelect = cs.DeckSelect;
            Dictionary<int, string> typeDic = new Dictionary<int, string>()
            {
                { 0,"Hearts"},
                {1,"Diamonds" },
                {2,"Clubs" },
                {3,"Spikes" }
            };
            int limit;
            string path;
            string extension;
            if (DeckSelect == "francesa")
            {
                limit = 14;
                path = "Assets/Deck/";
                extension = ".png";
            }
            else
            {
                limit = 13;
                path = "Assets/SpanishDeck/";
                extension = ".jpg";
            }

            for (int i = 0; i < 4; i++)
            {
                string type = typeDic[i];
                for (int j = 1; j < limit; j++)
                {
                    int number = j;
                    string source = $"{path}{j}{(typeDic[i] as string).ToUpper()[0]}{extension}";
                    Card c = new Card(number, type, source);
                    c.MouseDown += Image_MouseDown;
                    c.MouseUp += Image_MouseUp;
                    toSerialize.Add(c);
                }
            }
            
        }

        

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (!(sender as Image).IsDescendantOf(Players.FirstOrDefault(x => x.active == true).HandArea))
            {
                return;
            }
            MouseIsDown = false;
            Point mouse = Mouse.GetPosition(Application.Current.MainWindow);
            if (mouse.X > boundary.X && mouse.Y >boundary.Y && mouse.X < boundary.X+PlayArea.Width && mouse.Y<PlayArea.Height+boundary.Y)
            {
                if((sender as Card).PlayCard(activeCard))
                {
                    PlayArea.Children.Remove(activeCard);
                    Player targetPlayer = Players.FirstOrDefault(x => x.active == true);
                    targetPlayer.HandArea.ColumnDefinitions.RemoveAt(Grid.GetColumn(sender as Card));
                    targetPlayer.hand.Remove(sender as Card);
                    activeCard = sender as Card;
                    
                    
                    targetPlayer.HandArea.Children.Remove(sender as Card);
                    PlayArea.Children.Add(activeCard);
                    foreach (Card c in targetPlayer.hand)
                    {
                        Grid.SetColumn(c, targetPlayer.hand.IndexOf(c));
                    }
                    if (targetPlayer.hand.Count == 0)
                    {
                        targetPlayer.Win();
                        this.Close();
                    }
                    else
                    {
                       targetPlayer.NextPlayer(Players);
                    }
                   

                }
                
            }
            
                imagemoving.RenderTransform = new TranslateTransform { X = initial.X , Y = initial.Y };
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(!(sender as Image).IsDescendantOf(Players.FirstOrDefault(x=>x.active==true).HandArea))
            {
                return;
            }
            MouseIsDown = true;
            initialMouse= e.GetPosition(canvasTotal);
            imagemoving = (sender as Image);
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

            Players.Add(new Player("Jugador 1",playDeck , true, Player1HandArea, Player1Label));
            Players.Add(new Player("Jugador 2",playDeck , false, Player2HandArea, Player2Label));
            

        }

        private void PlayDeck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            (Players.FirstOrDefault(x => x.active == true) as Player).DrawCard(playDeck, 1);
            
        }

 
    }
}
