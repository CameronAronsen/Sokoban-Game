using System;
using System.Collections.Generic;
using System.Text;

namespace SokobanGame
{
    sealed public class Goal : Square
    {
        public Goal(int newRow, int newColumn)
        {
            _row = newRow;
            _column = newColumn;
        }

        public override void PrintSquare()
        {
            Console.WriteLine("This square is a Goal");
            base.PrintSquare();
        }

    }
}
