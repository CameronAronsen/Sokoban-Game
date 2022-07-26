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
    /// Interaction logic for FinishScreen.xaml
    /// </summary>
    public partial class FinishScreen : Window
    {
        Controller controller;
        MainWindow window;
        Label moveCount;

        public FinishScreen(Controller control, MainWindow win)
        {
            InitializeComponent();

            controller = control;
            window = win;
            moveCount = (Label)FindName("MoveCount");
            moveCount.Content = controller.GetMoveCount().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            controller.Restart();
            window.ResetLevel();
            window.SetCanMove(true);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
