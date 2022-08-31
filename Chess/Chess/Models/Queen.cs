using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Chess.Models
{
    public class Queen : Piece
    {
        public Queen(bool white) : base(white)
        {
      
        }
        public override List<Square> SelectPath(List<Square> squares, Square start)
        {          
            return null;
        }
    }
}