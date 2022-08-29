using System.Collections.Generic;

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
            }
            return result;
        }

        public List<Square> AttackRight(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            if (!start.Piece.White)
            {
                x++;
                y--;

                if (x < 8 && y >= 0)
                {

                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null)
                    {
                        if (sq.Piece.White)
                        {
                            result.Add(sq);

                        }
                    }
                }
            }
            else
            {
                x--;
                y++;

                if (y < 8 && x >= 0)
                {

                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null)
                    {
                        if (!sq.Piece.White)

                        {
                            result.Add(sq);

                        }
                    }



                }

            }
            return result;
        }
        public List<Square> AttackLeft(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            if (!start.Piece.White)
            {
                x++;
                y++;

                if (x < 8 && y < 8)
                {

                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null)
                    {


                        if (sq.Piece.White)
                        {
                            result.Add(sq);

                        }
                    }



                }

            }
            else
            {
                x--;
                y--;

                if (x >= 0 && y >= 0)
                {

                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null)

                        if (!sq.Piece.White)
                        {
                            result.Add(sq);
                        }
                }

            }
            return result;
        }
        public override List<Square> SelectPath(List<Square> squares, Square start)
        {

            List<Square> up = UpPath(squares, start);
            List<Square> attackRight = AttackRight(squares, start);
            List<Square> attackLeft = AttackLeft(squares, start);
            List<Square> result = new List<Square>();
            result.AddRange(up);
            result.AddRange(attackRight);
            result.AddRange(attackLeft);
            return result;
      //    List <Square> result= new List<Square>();

        }
    }
}
