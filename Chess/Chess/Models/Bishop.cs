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
        public override bool CanMove(Square start, Square end)
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
        public List<Square> upLeftPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {
                
                if(x > 0 && y > 0)
                {
                    x--;
                    y--;
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                if (x == 0 || y == 0)
                {
                    break;
                }
            }
            return result;
        }
        public List<Square> upRightPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {

                if (x > 0 && y < 8)
                {
                    x--;
                    y++;
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                if (x == 0 || y == 8)
                {
                    break;
                }
            }
            return result;
        }
        public List<Square> downRightPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {

                if (x < 8 && y < 8)
                {
                    x++;
                    y++;
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                if (x == 8 || y == 8)
                {
                    break;
                }
            }
            return result;
        }
        public List<Square> downLeftPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {

                if (x < 8 && y < 8)
                {
                    x++;
                    y--;
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                if (x == 8 || y == 8)
                {
                    break;
                }
            }
            return result;
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
                    Square square = squares[index - a * 7];
                    if(CanMove(start, square))
                    {
                        if (square.Piece == null)
                        {
                            result.Add(square);
                        }
                    }

                }
                if (index - a * 9 > 0)
                {
                    Square square = squares[index - a * 9];
                    if (CanMove(start, square))
                    {
                        if (square.Piece == null)
                        {
                            result.Add(square);
                        }
                    }
                }
                if (index + a * 7 <64)
                {
                    Square square = squares[index + a * 7];
                    if (CanMove(start, square))
                    {
                        if (square.Piece != null)
                        {
                            result.Add(square);
                        }
                    }
                }
                if (index + a * 9 < 64)
                {
                    Square square = squares[index + a * 9];
                        if (CanMove(start, square))
                        {
                            if (square.Piece != null)
                            {
                                result.Add(square);
                            }
                        }
                }
                a++;
            }
            return result;
        }
    }
}
