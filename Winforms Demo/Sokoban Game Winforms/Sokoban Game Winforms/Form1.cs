using Sokoban_Game_Winforms.Properties;
using SokobanGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sokoban_Game_Winforms
{
    public partial class Form1 : Form
    {
        static List<SquareWrapper> listOfSquaresVisual = new List<SquareWrapper>();
        PictureBox thePlayer;
        Controller controller = new();
        Control[] moveCount;
        bool canMove = true;

        public Form1()
        {
            InitializeComponent();
            controller.Start();

            moveCount = this.Controls.Find("MoveCount", true);
            CreateLevelVisual();

        }



        public void CreateLevelVisual()
        {
            Game game = controller.GetGame();
            foreach(Square square in game.ReturnSquares())
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

            moveCount[0].Text = controller.GetMoveCount().ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (canMove)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Left);
                        break;
                    case Keys.Up:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Up);
                        break;
                    case Keys.Right:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Right);
                        break;
                    case Keys.Down:
                        controller.SaveLastMove();
                        controller.MovePlayer(Direction.Down);
                        break;
                    case Keys.Space:
                        controller.Restart();
                        break;
                    case Keys.Escape:
                        ShowPauseMenu();
                        break;
                    case Keys.Back:
                        controller.LoadLastMove();
                        break;
                }

                ResetLevel();


                if (controller.CheckWin() == true)
                {
                    canMove = false;
                    Form2 form2 = new Form2(controller, this);
                    form2.Show();
                }
            }


        }

        public void ShowPauseMenu()
        {
            Form3 form3 = new Form3(controller, this);
            canMove = false;
            form3.Show();
        }

        public void ResetLevel()
        {
            foreach (SquareWrapper square in listOfSquaresVisual)
            {
                PictureBox picture = square.GetImage();
                picture.Dispose();
            }

            thePlayer.Dispose();

            CreateLevelVisual();
        }

        public void CreateWall(int row, int column)
        {
            PictureBox wall = new PictureBox()
            {
                Name = "Wall",
                Size = new Size(60, 60),
                Location = new Point(((ClientSize.Width/2) - (60 * 5)) + (60 * column), ((ClientSize.Height / 2) - (60 * 5)) + (60 * row)),
                Image = Resources.Wall,
                Anchor = AnchorStyles.None,
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, wall));
            this.Controls.Add(wall);
        }

        public void CreateBlock(int row, int column)
        {
            PictureBox block = new PictureBox()
            {
                Name = "Block",
                Size = new Size(60, 60),
                Location = new Point(((ClientSize.Width / 2) - (60 * 5)) + (60 * column), ((ClientSize.Height / 2) - (60 * 5)) + (60 * row)),
                Image = Resources.Block,
                Anchor = AnchorStyles.None,
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, block));
            this.Controls.Add(block);
            block.BringToFront();
        }

        public void CreateGoal(int row, int column)
        {
            PictureBox goal = new PictureBox()
            {
                Name = "Goal",
                Size = new Size(60, 60),
                Location = new Point(((ClientSize.Width / 2) - (60 * 5)) + (60 * column), ((ClientSize.Height / 2) - (60 * 5)) + (60 * row)),
                Image = Resources.Goal,
                Anchor = AnchorStyles.None,
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, goal));
            this.Controls.Add(goal);
        }

        public void CreatePlayer(int row, int column)
        {
            PictureBox player = new PictureBox()
            {
                Name = "Player",
                Size = new Size(60, 60),
                Location = new Point(((ClientSize.Width / 2) - (60 * 5)) + (60 * column), ((ClientSize.Height / 2) - (60 * 5)) + (60 * row)),
                Image = Resources.Player,
                Anchor = AnchorStyles.None,
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, player));
            this.Controls.Add(player);
            player.BringToFront();
            thePlayer = player;
        }

        public void CreateEmpty(int row, int column)
        {
            PictureBox empty = new PictureBox()
            {
                Name = "Empty",
                Size = new Size(60, 60),
                Location = new Point(((ClientSize.Width / 2) - (60 * 5)) + (60 * column), ((ClientSize.Height / 2) - (60 * 5)) + (60 * row)),
                Anchor = AnchorStyles.None,
            };

            listOfSquaresVisual.Add(new SquareWrapper(row, column, empty));
            this.Controls.Add(empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.DoubleBuffered = true;
        }

        public void SetCanMove(bool setting) => canMove = setting;
    }
}
