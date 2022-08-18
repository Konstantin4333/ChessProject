using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Bishop : Piece
    {
        int[] steps = { 7, 9, -7, -9};
        public Bishop(bool white) : base(white)
        {
            AttachImage(white);

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
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_bishop.jpg", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_bishop.jpg", UriKind.Relative));
            }
        }
        public override bool CanMove(Board board, Square start, Square end)
        {
            if (end.Piece != null)
            {
                if (end.Piece.White == start.Piece.White)
                {
                    return false;
                }
            }
            
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            if (x == y)
            {
                return true;
            }

         
            return false;
        }
        

        public override List<Square> CheckPath(ObservableCollection<Square> squares, Square start)
        {
            int index = squares.IndexOf(start);
            int a = 1;
            List<Square> result = new List<Square>();
            while (true)
            {
                if (index - a*7>0)
                {
                    Square square = squares[a * 7];
                    
                    if (square.Piece != null)
                    {
                        result.Add(square);
                    }
                }
                if (index - a * 9 > 0)
                {
                    Square square = squares[a * 9];
                    if (square.Piece != null)
                    {
                        result.Add(square);
                    }
                }
                if (index + a * 7 <64)
                {
                    Square square = squares[a * 7];
                    if (square.Piece != null)
                    {
                        result.Add(square);
                    }
                }
                if (index + a * 9 < 64)
                {
                    Square square = squares[a * 9];
                    if (square.Piece != null)
                    {
                        result.Add(square);
                    }
                }
            }
        }
    }
}
