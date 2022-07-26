using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban_Game_Winforms
{
    class SquareWrapper
    {
        private int _row;
        private int _column;

        private PictureBox _image;

        public SquareWrapper(int newRow, int newColumn, PictureBox startingImage)
        {
            _row = newRow;
            _column = newColumn;
            _image = startingImage;
            _image.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int GetRow() => _row;
        public int GetColumn() => _column;
        public PictureBox GetImage() => _image;

        public void SetRow(int newRow) => _row = newRow;
        public void SetColumn(int newColumn) => _column = newColumn;
        public void SetImage(Bitmap newImage) => _image.Image = newImage;

        public override string ToString()
        {
            return $"This PictureBox is on row: {_row}, column: {_column}";
        }
    }
}
