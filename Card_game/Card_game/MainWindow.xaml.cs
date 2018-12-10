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



        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            MouseIsDown = false;
            Point mouse = Mouse.GetPosition(Application.Current.MainWindow);
            if (mouse.X > boundary.X && mouse.Y >boundary.Y && mouse.X < boundary.X+Label1.Width && mouse.Y<Label1.Height+boundary.Y)
            {
                MessageBox.Show(Mouse.GetPosition(Application.Current.MainWindow).X.ToString()+" "+ Label1.Margin.Left);
            }
            else
            {
                imagemoving.RenderTransform = new TranslateTransform { X = initial.X , Y = initial.Y };
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            MouseIsDown = true;
            initial= e.GetPosition(sender as Image);
            imagemoving = (sender as Image);
            //initial = new Point( Canvas.GetLeft(imagemoving), Canvas.GetTop(imagemoving));
            
        }


        private void CanvasTotal_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {

                Point p = Mouse.GetPosition(Application.Current.MainWindow);
                double xOffset = p.X - initial.X;
                double yOffset = p.Y - initial.Y;
                imagemoving.RenderTransform = new TranslateTransform { X = xOffset, Y = yOffset };
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            boundary = new Point(Canvas.GetLeft(Label1), Canvas.GetTop(Label1));
        }
    }
}
