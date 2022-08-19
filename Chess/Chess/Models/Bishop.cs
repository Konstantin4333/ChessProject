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
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_bishop.png", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_bishop.png", UriKind.Relative));
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
        public List<Square> UpLeftPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {
                x--;
                y--;
                if (x >= 0 && y >= 0)
                {
                    
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                else
                {
                    break;

                }


            }
            return result;
        }
        public List<Square> UpRightPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {
                x--;
                y++;
                if (x >= 0 && y < 8)
                {
                    
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                else
                {
                    break;
                }
                  
            }
            return result;
        }
        public List<Square> DownRightPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {
                x++;
                y++;
                if (x < 8 && y < 8)
                {
                    
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                else
                {
                    break;
                }
                   
                
            }
            return result;
        }
        public List<Square> DownLeftPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            while (true)
            {
                x++;
                y--;
                if (x < 8 && y >=0)
                {
                    
                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null) result.Add(sq);
                    else break;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
        public override List<Square> SelectPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> upLeft= UpLeftPath(squares, start);
            List<Square> downLeft= DownLeftPath(squares, start);
           List<Square> upRight = UpRightPath(squares, start);
            List<Square> downRight = DownRightPath(squares, start);
            List<Square> result = new List<Square>();

            result.AddRange(upLeft);
            result.AddRange(downLeft);
            result.AddRange(downRight);
            result.AddRange(upRight);

            return result;
        }
    }
}
