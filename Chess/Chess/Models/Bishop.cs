using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Bishop : Piece
    {
        public Bishop(bool white) : base(white)
        {

        }

        public override bool canMove(Board board, Square start, Square end)
        {
            if (end.Piece.White == start.Piece.White)
            {
                return false;
            }
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            if (x == y)
            {
                return true;
            }
            return false;
        }
    }
}
