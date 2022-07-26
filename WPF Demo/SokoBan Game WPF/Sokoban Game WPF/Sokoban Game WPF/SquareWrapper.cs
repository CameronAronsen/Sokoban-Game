using System;
using System.Collections.Generic;
using System.Drawing;
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
using SokobanGame;


namespace Sokoban_Game_WPF
{
    class SquareWrapper
    {
        private int _row;
        private int _column;

        private Image _image;

        public SquareWrapper(int newRow, int newColumn, Image startingImage)
        {
            _row = newRow;
            _column = newColumn;
            _image = startingImage;
            _image.Stretch = Stretch.Fill;
        }

        public int GetRow() => _row;
        public int GetColumn() => _column;
        public Image GetImage() => _image;

        public void SetRow(int newRow) => _row = newRow;
        public void SetColumn(int newColumn) => _column = newColumn;
        public void SetImage(BitmapImage newImage) => _image.Source = newImage;

        public override string ToString()
        {
            return $"This PictureBox is on row: {_row}, column: {_column}";
        }
    }
}
