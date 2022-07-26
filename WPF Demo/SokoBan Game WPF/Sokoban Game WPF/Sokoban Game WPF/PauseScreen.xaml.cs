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

namespace Sokoban_Game_WPF
{
    /// <summary>
    /// Interaction logic for PauseScreen.xaml
    /// </summary>
    public partial class PauseScreen : Window
    {
        Controller controller;
        MainWindow window;
        public PauseScreen(Controller control, MainWindow win)
        {
            InitializeComponent();

            controller = control;
            window = win;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.SaveGame();

            window.SetCanMove(true);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            controller.LoadGame();
            window.ResetLevel();

            window.SetCanMove(true);
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            window.SetCanMove(true);
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
