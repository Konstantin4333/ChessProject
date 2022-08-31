using System.Collections.Generic;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Chess.Models
{
    public  class Piece
    {
        public Piece()
        {
            //White = white;
        }
        public ImageSource ImageOfPiece { get; set; }
        public bool White { get; set; }
        //public abstract List<Square> SelectPath(List<Square> squares, Square start);
    }
}
