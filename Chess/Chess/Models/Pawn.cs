using Chess.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Pawn : Piece
    {

        public Pawn(bool white) : base(white)
        {
            
        }
      
        public List<Square> UpPath(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;


            if (!start.Piece.White)
            {
                x++;


                if (x < 8 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                    if (x == 2)
                    {
                        x++;
                        index = x * 8 + y;
                        Square sq1 = squares[index];
                        if (sq1.Piece == null)
                        {
                            result.Add(sq1);
                        }
                    }
                }

            }
            else
            {
                x--;
                if (x >= 0 && y >= 0)
                {

                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                    if (x == 5)
                    {
                        x--;
                        index = x * 8 + y;
                        Square sq2 = squares[index];
                        if (sq2.Piece == null)
                        {
                            result.Add(sq2);
                        }
                    }
                }
            }
            return result;
        }
        public List<Square> Attack(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            Square currentSquare;
            int c = 1;
            if (start.Piece.White == true) c = -1;
            if (start.X + c < 8 && start.X + c > 0 && start.Y + 1 < 8)
            {

                currentSquare = squares[(start.X + c) * 8 + (start.Y + 1)];
                if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White)
                    result.Add(currentSquare);
            }
            if (start.X + c < 8 && start.X + c > 0 && start.Y - 1 >= 0)
            {
                currentSquare = squares[(start.X + c) * 8 + (start.Y - 1)];
                if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White)
                    result.Add(currentSquare);
            }

            return result;
        }
        public override List<Square> SelectPath(List<Square> squares, Square start)
        {
            List<Square> up = UpPath(squares, start);        
            List<Square> attack = Attack(squares, start);
            List<Square> result = new List<Square>();
            result.AddRange(up);
            result.AddRange(attack);
            return result;
        }
    }
}