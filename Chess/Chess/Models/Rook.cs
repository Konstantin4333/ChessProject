using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Rook : Piece
    {
        public Rook(bool white) : base(white)
        {
          
        }        
        public override List<Square> SelectPath(List<Square> squares, Square start)
        {           
            return null;
        }
    }
}
