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
        

        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = Mouse.GetPosition(Application.Current.MainWindow);
            ((Button)sender).TranslatePoint(point, Application.Current.MainWindow);
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point point = Mouse.GetPosition(Application.Current.MainWindow);
            ((Button)sender).TranslatePoint(point, Application.Current.MainWindow);
        }
    }
}
