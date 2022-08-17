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
        public override bool CheckPath(ObservableCollection<Square> squares, Square PrevSquare, Square SelectedSquare)
        {
            int indexPrev = squares.IndexOf(PrevSquare);
            int indexSquare = squares.IndexOf(SelectedSquare);
            if(indexPrev < indexSquare)
            {
                int diff = indexSquare - indexPrev;
                for (int i = 0; i <diff/9 ; i++)
                {
                    if (squares[indexPrev + 9] != null)
                        return false;
                }
                if ((diff) % 9 == 0)
                {
                    
                    
                }
            }
            else
            {
                int diff = indexPrev- indexSquare;
                if ((diff) % 9 == 0)
                {
                    if (squares[diff] != null)
                        return false;
                }
            }
            return false;
        }

        
    }
}
