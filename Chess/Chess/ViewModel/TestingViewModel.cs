using Chess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.ViewModel
{
    public class TestingViewModel:BaseViewModel
    {
        public int TestingRow { get; set; }
        public int TestingColumn { get; set; }
        public string Rows { get; set; }
        public string Columns { get; set; }


        public TestingViewModel()
        {
            TestingRow = 5;
            TestingColumn = 3;

        }


        BitmapImage carBitmap = new BitmapImage(new Uri("Chess/Pictures/chess_piece_black_bishop.jpg", UriKind.Absolute));
    }
    
}
  