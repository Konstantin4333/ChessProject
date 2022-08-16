using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Bishop : Piece
    {

             Bitmap bmp = new Bitmap(
              System.Reflection.Assembly.GetEntryAssembly().
             GetManifestResourceStream("Chess/Pictures/chess_piece_black_bishop.jpg"));
        public Bishop(bool white) : base(white)
        {
                
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
            for (int i = 0; i<x; i++)
            {
                if (board.GetSquare(i, i) != null)
                {

                }
                 
            }
            return false;
        }
    }

    internal class Bitmap
    {
        private Stream? stream;

        public Bitmap(Stream? stream)
        {
            this.stream = stream;
        }
    }
}
