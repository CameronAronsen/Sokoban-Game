using System;

namespace SokobanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.CreateLevel(3, 1);
            game.AddPlayer(0, 0);
            game.AddBlock(1, 0);
            game.AddGoal(2, 0);
            do
            {
                Console.WriteLine("There is a player at 0, 0. A block at 1,0. And a goal at 2,0");
                Console.WriteLine("Which way do you want to move?");
                string dir = Console.ReadLine();
                switch (dir)
                {
                    case "up":
                        game.Move(Direction.Up);
                        break;
                    case "down":
                        game.Move(Direction.Down);
                        break;
                    case "left":
                        game.Move(Direction.Left);
                        break;
                    case "right":
                        game.Move(Direction.Right);
                        break;
                }

            } while (!game.IsFinished());
            Console.WriteLine("\n");

            Console.WriteLine("Good job");
        }
    }
}
