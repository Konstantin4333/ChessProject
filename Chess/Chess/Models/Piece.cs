using System.Collections.Generic;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Chess.Models
{
    public abstract class Piece
    {
        public Piece(bool white)
        {
            White = white;
        }
        public ImageSource ImageOfPiece { get; set; }
        public bool White { get; set; }
        public abstract List<Square> SelectPath(List<Square> squares, Square start);
    }
}
