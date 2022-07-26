using SokobanGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Sokoban_Game_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<SquareWrapper> listOfSquaresVisual = new List<SquareWrapper>();
        Image thePlayer;
        Controller controller = new();
        Label moveCount;
        bool canMove = true;
        Grid childGrid;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);


        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += Form1_KeyDown;

            controller.Start();

            childGrid = new Grid();
            moveCount = (Label)FindName("MoveCount");
            childGrid.HorizontalAlignment = HorizontalAlignment.Center;
            childGrid.VerticalAlignment = VerticalAlignment.Center;
            CreateLevelVisual();
            MainGrid.Children.Add(childGrid);
        }

        public void CreateLevelVisual()
        {
            Game game = controller.GetGame();
            foreach (Square square in game.ReturnSquares())
            {
                switch (square.GetType().Name)
                {
                    case "Wall":
                        CreateWall(square.GetRow(), square.GetColumn());
                        break;
                    case "Block":
                        CreateBlock(square.GetRow(), square.GetColumn());
                        break;
                    case "Goal":
                        CreateGoal(square.GetRow(), square.GetColumn());
                        break;
                    case "Empty":
                        CreateEmpty(square.GetRow(), square.GetColumn());
                        break;
                }
            }

            CreatePlayer(game.GetPlayerRow(), game.GetPlayerColumn());

            moveCount.Content = controller.GetMoveCount().ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (canMove)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Left);
                        break;
                    case Key.Up:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Up);
                        break;
                    case Key.Right:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Right);
                        break;
                    case Key.Down:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Down);
                        break;
                    case Key.Space:
                        controller.Restart();
                        break;
                    case Key.Escape:
                        ShowPauseMenu();
                        break;
                    case Key.Back:
                        controller.LoadLastMove();
                        break;
                }

                ResetLevel();


                if (controller.CheckWin() == true)
                {
                    FinishScreen fin = new FinishScreen(controller, this);
                    fin.Show();
                    canMove = false;
                }
            }


        }

        public void ResetLevel()
        {
            foreach (SquareWrapper square in listOfSquaresVisual)
            {
                Image picture = square.GetImage();
                picture.Visibility = Visibility.Hidden;
            }
            listOfSquaresVisual.Clear();
            thePlayer.Visibility = Visibility.Hidden;

            CreateLevelVisual();
        }

        public void ShowPauseMenu()
        {
            canMove = false;
            PauseScreen pause = new PauseScreen(controller, this);
            pause.Show();
        }

        public void CreatePlayer(int row, int column)
        {
            Image player = new Image();
            player.Name = "Player";
            player.Width = 60;
            player.Height = 60;
            player.RenderTransform = new TranslateTransform(((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * column), ((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * row));
            player.Source = new BitmapImage(new Uri("/Sokoban Game WPF;component/Images/Man.png", UriKind.Relative));
            Canvas.SetZIndex(player, 5);


            listOfSquaresVisual.Add(new SquareWrapper(row, column, player));
            childGrid.Children.Add(player);
            thePlayer = player;
        }

        public void CreateWall(int row, int column)
        {
            Image wall = new Image()
            {
                Name = "Wall",
                Width = 60,
                Height = 60,
                RenderTransform = new TranslateTransform(((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * column), ((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * row)),
                Source = new BitmapImage(new Uri("/Sokoban Game WPF;component/Images/Wall.jpg", UriKind.Relative)),
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, wall));
            childGrid.Children.Add(wall);
        }

        public void CreateGoal(int row, int column)
        {
            Image goal = new Image()
            {
                Name = "Goal",
                Width = 60,
                Height = 60,
                RenderTransform = new TranslateTransform(((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * column), ((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * row)),
                Source = new BitmapImage(new Uri("/Sokoban Game WPF;component/Images/Goal.jpg", UriKind.Relative)),
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, goal));
            childGrid.Children.Add(goal);
        }

        public void CreateBlock(int row, int column)
        {
            Image block = new Image()
            {
                Name = "Block",
                Width = 60,
                Height = 60,
                RenderTransform = new TranslateTransform(((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * column), ((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * row)),
                Source = new BitmapImage(new Uri("/Sokoban Game WPF;component/Images/Block.jpg", UriKind.Relative)),
            };

            Canvas.SetZIndex(block, 5);

            listOfSquaresVisual.Add(new SquareWrapper(row, column, block));
            childGrid.Children.Add(block);
        }

        public void CreateEmpty(int row, int column)
        {
            Image empty = new Image()
            {
                Name = "Empty",
                Width = 60,
                Height = 60,
                RenderTransform = new TranslateTransform(((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * column), ((childGrid.ActualWidth / 2) - (60 * 5)) + (60 * row)),
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, empty));
            childGrid.Children.Add(empty);
        }

        public void SetCanMove(bool setting) => canMove = setting;

    }
}
