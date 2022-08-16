using Chess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Chess.ViewModel
{
    public class RowsAndColumnsViewModel
    {
        public int TestingRow { get; set; }
        public int TestingColumn { get; set; }
         public string  Rows { get;set; }
        public string Columns { get; set; }
        public Bitmap pic { get; set; }

      
        public RowsAndColumnsViewModel()
        {
            TestingRow = 5;
            TestingColumn = 3;
            Bitmap bmp = new Bitmap(
           System.Reflection.Assembly.GetEntryAssembly().
          GetManifestResourceStream("Chess/Pictures/chess_piece_black_bishop.jpg"));
        }
                
         
        BitmapImage carBitmap = new BitmapImage(new Uri("Chess/Pictures/chess_piece_black_bishop.jpg", UriKind.Absolute));

        
    }

    
}
  