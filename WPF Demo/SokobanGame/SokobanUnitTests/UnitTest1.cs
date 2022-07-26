using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanGame;
using System;

namespace SokobanUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Game newGame = new Game();
        
        //Creating Levels
        [TestMethod]
        public void TestGameHasNoLevels()
        {
            int expected = 0;
            int actual = newGame.GetLevelCount();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGameHasOneLevel()
        {
            newGame.CreateLevel(5, 5);

            int expected = 1;
            int actual = newGame.GetLevelCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGameHasTwoLevels()
        {
            newGame.CreateLevel(5, 5);
            newGame.CreateLevel(1, 1);

            int expected = 2;
            int actual = newGame.GetLevelCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRecentLevelIsCorrect()
        {
            newGame.CreateLevel(5, 5);
            newGame.CreateLevel(1, 1);

            (int, int) expected = (1, 1);
            (int, int) actual = (newGame.GetLevelWidth(), newGame.GetLevelHeight());
            Assert.AreEqual(expected, actual);
        }

        //Level Sizes
        [TestMethod]
        public void TestLevelWidthIsCorrect()
        {
            newGame.CreateLevel(5, 5);

            int expected = 5;
            int actual = newGame.GetLevelWidth();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLevelHeightIsCorrect()
        {
            newGame.CreateLevel(5, 5);

            int expected = 5;
            int actual = newGame.GetLevelHeight();
            Assert.AreEqual(expected, actual);
        }
        
        //Adding Player
        [TestMethod]
        public void TestPlayerRowIsCorrect()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(1, 3);

            int expected = 3;
            int actual = newGame.GetPlayerRow();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerColumnIsCorrect()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(1, 3);

            int expected = 1;
            int actual = newGame.GetPlayerColumn();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerCantBeOutsideLevelWidth()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(6, 3);

            //getPlayerColumn returns 0 if there isnt a player
            int expected = 0;
            int actual = newGame.GetPlayerColumn();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerCantBeOutsideLevelHeight()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 6);

            //getPlayerRow returns 0 if there isnt a player
            int expected = 0;
            int actual = newGame.GetPlayerRow();
            Assert.AreEqual(expected, actual);
        }

        //Player Movement
        [TestMethod]
        public void TestPlayerMovesUp()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);
            newGame.Move(Direction.Up);

            (int, int) expected = (3, 2);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerMovesDown()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);
            newGame.Move(Direction.Down);

            (int, int) expected = (3, 4);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerMovesLeft()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);
            newGame.Move(Direction.Left);

            (int, int) expected = (2, 3);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerMovesRight()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);
            newGame.Move(Direction.Right);

            (int, int) expected = (4, 3);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        //Test Placing Walls and Goals and Blocks
        [TestMethod]
        public void TestWallIsCorrectPos()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddWall(1, 1);

            String expected = "Wall";
            String actual = newGame.GetTargetSquare(1, 1).GetType().Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBlockIsCorrectPos()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddBlock(1, 1);

            String expected = "Block";
            String actual = newGame.GetTargetSquare(1, 1).GetType().Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGoalIsCorrectPos()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddGoal(1, 1);

            String expected = "Goal";
            String actual = newGame.GetTargetSquare(1, 1).GetType().Name;
            Assert.AreEqual(expected, actual);
        }


        //Test Player Cant Move Through or On Walls
        [TestMethod]
        public void TestPlayerCantMoveThroughWallUp()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddWall(1, 1);
            newGame.AddPlayer(1, 2);
            newGame.Move(Direction.Up);

            (int, int) expected = (1, 2);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerCantMoveThroughWallDown()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddWall(1, 1);
            newGame.AddPlayer(1, 0);
            newGame.Move(Direction.Down);

            (int, int) expected = (1, 0);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerCantMoveThroughWallLeft()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddWall(0, 1);
            newGame.AddPlayer(1, 1);
            newGame.Move(Direction.Left);

            (int, int) expected = (1, 1);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerCantMoveThroughWallRight()
        {
            newGame.CreateLevel(2, 3);
            newGame.AddWall(1, 1);
            newGame.AddPlayer(0, 1);
            newGame.Move(Direction.Right);

            (int, int) expected = (0, 1);
            (int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow());
            Assert.AreEqual(expected, actual);
        }

        //Test Player Can Push Blocks
        [TestMethod]
        public void TestPlayerMovesBlockUp()
        {
            newGame.CreateLevel(1, 5);
            newGame.AddPlayer(0, 3);
            newGame.AddBlock(0, 2);
            newGame.Move(Direction.Up);

            (int, int, String, int, int) expected = (0, 2, "Block", 0, 1);
            (int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(0, 1).GetType().Name,
                                                   newGame.GetTargetSquare(0, 1).GetColumn(), newGame.GetTargetSquare(0, 1).GetRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerMovesBlockDown()
        {
            newGame.CreateLevel(1, 5);
            newGame.AddPlayer(0, 2);
            newGame.AddBlock(0, 3);
            newGame.Move(Direction.Down);

            (int, int, String, int, int) expected = (0, 3, "Block", 0, 4);
            (int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(0, 4).GetType().Name,
                                                   newGame.GetTargetSquare(0, 4).GetColumn(), newGame.GetTargetSquare(0, 4).GetRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerMovesBlockLeft()
        {
            newGame.CreateLevel(5, 1);
            newGame.AddPlayer(3, 0);
            newGame.AddBlock(2, 0);
            newGame.Move(Direction.Left);

            (int, int, String, int, int) expected = (2, 0, "Block", 1, 0);
            (int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(1, 0).GetType().Name,
                                                   newGame.GetTargetSquare(1, 0).GetColumn(), newGame.GetTargetSquare(1, 0).GetRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerMovesBlockRight()
        {
            newGame.CreateLevel(5, 1);
            newGame.AddPlayer(2, 0);
            newGame.AddBlock(3, 0);
            newGame.Move(Direction.Right);

            (int, int, String, int, int) expected = (3, 0, "Block", 4, 0);
            (int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(4, 0).GetType().Name,
                                                   newGame.GetTargetSquare(4, 0).GetColumn(), newGame.GetTargetSquare(4, 0).GetRow());
            Assert.AreEqual(expected, actual);
        }

        //Test Blocks cant move if Blocked on Other Side
            
            //Tests that Player cant move onto a block, that block cant move onto a wall, and it cant move when blocked by a wall
        [TestMethod]
        public void TestBlockDoesntMoveWhenWallOnOtherSide()
        {
            newGame.CreateLevel(1, 5);
            newGame.AddPlayer(0, 4);
            newGame.AddBlock(0, 3);
            newGame.AddWall(0, 2);
            newGame.Move(Direction.Up);

            (int, int, String, int, int, String, int, int) expected = (0, 4, "Block", 0, 3, "Wall", 0, 2);
            (int, int, String, int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(0,3).GetType().Name,
                                                    newGame.GetTargetSquare(0, 3).GetColumn(), newGame.GetTargetSquare(0, 3).GetRow(), newGame.GetTargetSquare(0, 2).GetType().Name,
                                                    newGame.GetTargetSquare(0, 2).GetColumn(), newGame.GetTargetSquare(0, 2).GetRow());
            Assert.AreEqual(expected, actual);
        }
            //Tests that Player cant move onto a block, that block cant move onto another block, and it cant move when blocked by another block
        [TestMethod]
        public void TestBlockDoesntMoveWhenBlockOnOtherSide()
        {
            newGame.CreateLevel(1, 5);
            newGame.AddPlayer(0, 4);
            newGame.AddBlock(0, 3);
            newGame.AddBlock(0, 2);
            newGame.Move(Direction.Up);

            (int, int, String, int, int, String, int, int) expected = (0, 4, "Block", 0, 3, "Block", 0, 2);
            (int, int, String, int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(0, 3).GetType().Name,
                                                    newGame.GetTargetSquare(0, 3).GetColumn(), newGame.GetTargetSquare(0, 3).GetRow(), newGame.GetTargetSquare(0, 2).GetType().Name,
                                                    newGame.GetTargetSquare(0, 2).GetColumn(), newGame.GetTargetSquare(0, 2).GetRow());
            Assert.AreEqual(expected, actual);
        }

        //Test Player Can move on and off Goals
        [TestMethod]
        public void TestPlayerCanMoveOnGoal()
        {
            newGame.CreateLevel(5, 1);
            newGame.AddPlayer(2, 0);
            newGame.AddGoal(3, 0);
            newGame.Move(Direction.Right);

            (int, int, String, int, int) expected = (3, 0, "Goal", 3, 0);
            (int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(3, 0).GetType().Name,
                                                   newGame.GetTargetSquare(3, 0).GetColumn(), newGame.GetTargetSquare(3, 0).GetRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlayerCanMoveOffGoal()
        {
            newGame.CreateLevel(5, 1);
            newGame.AddPlayer(3, 0);
            newGame.AddGoal(3, 0);
            newGame.Move(Direction.Right);

            (int, int, String, int, int) expected = (4, 0, "Goal", 3, 0);
            (int, int, String, int, int) actual = (newGame.GetPlayerColumn(), newGame.GetPlayerRow(), newGame.GetTargetSquare(3, 0).GetType().Name,
                                                   newGame.GetTargetSquare(3, 0).GetColumn(), newGame.GetTargetSquare(3, 0).GetRow());
            Assert.AreEqual(expected, actual);
        }

        //Test Blocks Can Move On and Off Goals

        [TestMethod]
        public void TestBlockCanMoveOnGoal()
        {
            newGame.CreateLevel(5, 1);
            newGame.AddPlayer(1, 0);
            newGame.AddBlock(2, 0);
            newGame.AddGoal(3, 0);
            newGame.Move(Direction.Right);

            (String, int, int, String, int, int) expected = ("Block", 3, 0, "Goal", 3, 0);
            (String, int, int, String, int, int) actual = (newGame.GetTargetSquare(3, 0).GetType().Name, newGame.GetTargetSquare(3, 0).GetColumn(), newGame.GetTargetSquare(3, 0).GetRow(),
                                                           newGame.GetGoalAt(3, 0).GetType().Name, newGame.GetGoalAt(3, 0).GetColumn(), newGame.GetGoalAt(3, 0).GetRow());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBlockCanMoveOffGoal()
        {
            newGame.CreateLevel(5, 1);
            newGame.AddPlayer(2, 0);
            newGame.AddBlock(3, 0);
            newGame.AddGoal(3, 0);
            newGame.Move(Direction.Right);

            (String, int, int, String, int, int) expected = ("Block", 4, 0, "Goal", 3, 0);
            (String, int, int, String, int, int) actual = (newGame.GetTargetSquare(4, 0).GetType().Name, newGame.GetTargetSquare(4, 0).GetColumn(), newGame.GetTargetSquare(4, 0).GetRow(),
                                                           newGame.GetGoalAt(3, 0).GetType().Name, newGame.GetGoalAt(3, 0).GetColumn(), newGame.GetGoalAt(3, 0).GetRow());
            Assert.AreEqual(expected, actual);
        }

        //Test Moving Player Increases Move Count
        [TestMethod]
        public void TestMoveCountIncreasesByOne()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);
            newGame.Move(Direction.Up);

            int expected = 1;
            int actual = newGame.GetMoveCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveCountIncreasesByTwo()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);
            newGame.Move(Direction.Up);
            newGame.Move(Direction.Down);

            int expected = 2;
            int actual = newGame.GetMoveCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveCountIncreasesByZero()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(3, 3);

            int expected = 0;
            int actual = newGame.GetMoveCount();
            Assert.AreEqual(expected, actual);
        }

        //Test Blocks on Goal Finishes Level

        [TestMethod]
        public void TestOneBlockOnGoalFinishesLevel()
        {
            newGame.CreateLevel(1, 3);
            newGame.AddPlayer(0, 0);
            newGame.AddBlock(0, 1);
            newGame.AddGoal(0, 2);
            newGame.Move(Direction.Down);

            bool actual = newGame.IsFinished();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestTwoBlockOnGoalFinishesLevel()
        {
            newGame.CreateLevel(3, 3);
            newGame.AddPlayer(0, 0);
            newGame.AddBlock(0, 1);
            newGame.AddBlock(1, 1);
            newGame.AddGoal(0, 2);
            newGame.AddGoal(2, 1);

            newGame.Move(Direction.Down);
            newGame.Move(Direction.Right);

            bool actual = newGame.IsFinished();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestTwoBlockOnOneGoalDoesntFinish()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(0, 0);
            newGame.AddBlock(1, 0);
            newGame.AddBlock(0, 1);
            newGame.AddGoal(2, 1);
            newGame.AddGoal(2, 0);
            
            newGame.Move(Direction.Down);

            bool actual = newGame.IsFinished();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestTwoBlockOnSameGoalDoesntFinish()
        {
            newGame.CreateLevel(5, 5);
            newGame.AddPlayer(0, 0);
            newGame.AddBlock(0, 1);
            newGame.AddBlock(1, 2);
            newGame.AddGoal(0, 2);
            newGame.Move(Direction.Down);
            newGame.Move(Direction.Right);
            newGame.Move(Direction.Right);
            newGame.Move(Direction.Down);
            newGame.Move(Direction.Left);

            bool actual = newGame.IsFinished();
            Assert.IsFalse(actual);
        }
    }
}
