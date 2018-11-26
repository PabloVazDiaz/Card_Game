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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label1.Visibility = Visibility.Hidden;
            MouseIsDown = false;
            if (Mouse.GetPosition(Application.Current.MainWindow).X > Label1.Margin.Left && Mouse.GetPosition(Application.Current.MainWindow).Y >Label1.Margin.Top)
            {
                MessageBox.Show(Mouse.GetPosition(Application.Current.MainWindow).X.ToString()+" "+ Label1.Margin.Left);
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label1.Visibility = Visibility.Visible;
            MouseIsDown = true;
            initial = e.GetPosition(sender as Image);
            imagemoving = (sender as Image);

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void canvasTotal_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {

                Point p = Mouse.GetPosition(Application.Current.MainWindow);
                double xOffset = p.X - initial.X;
                double yOffset = p.Y - initial.Y;
                imagemoving.RenderTransform = new TranslateTransform { X = xOffset, Y = yOffset };
            }
        }
    }
}
