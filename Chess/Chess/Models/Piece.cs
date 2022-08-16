using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Models
{
    public abstract class Piece
    {
        public Piece(bool white)
        {
            White = white;
        }
        public ImageSource ImageOfPiece { get; set; }
        public int Row  { get; set; }
        public int Column { get; set; }
        public bool Killed { get; set; }
        public bool White { get; set; }
        public abstract bool CanMove(Board board, Square start, Square end);

    }
}
