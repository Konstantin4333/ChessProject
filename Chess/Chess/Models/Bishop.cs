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
        public Square[] getAvailableMoves(Board board, Square start)
        {
            Square[] squares= new Square[64];
            for (int i = 0; i < 64; i++)
            {
               Square sq = board.GetSquare(i);
                if (sq.Piece != null)
                {
                    if (sq.Piece.White == start.Piece.White)
                    {
                        squares[i] = sq;
                    }
                }
            }
            
            return new Square[0];   
        }
        public override bool CanMove(Board board, Square start, Square end)
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
