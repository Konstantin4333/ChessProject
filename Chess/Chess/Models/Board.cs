using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Board
    {
        public Square[] Squares { get; set; }


        public Board()
        {

            this.ResetBoard();
            this.CheckSquareEvent(Squares);

        }
        public Square GetSquare(int x)
        {
            if (x < 0 || x > 64)
            {
                throw new Exception("Index out of bounds");
            }
            return Squares[x];
        }
        public Square GetSquare(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                throw new Exception("Index out of bounds");
            }

            int index = x * 8 + y;
            return Squares[index];

        }


        //----------------------------
        public void CheckSquareEvent(Square[] sq)
        {
            bool f = false;
            // Squares = new Square[64];
            for (int i = 0; i < 64; i++)
            {

                if (i % 8 == 0)
                {
                    f = !f;
                }
                if (i % 2 == 0)
                {
                    sq[i].IsEven = f;
                }

                else
                {


                    if (i % 2 != 0)
                    {
                        sq[i].IsEven = !f;
                    }
                }


            }

            /* f = true;
             sq[i].IsEven = true;*/

            Console.WriteLine();

        }






        public void ResetBoard()
        {
            //Initialize black pieces
            Squares = new Square[64];
            Squares[0] = new Square(0, 0, new Rook(false));
            Squares[1] = new Square(0, 1, new Knight(false));
            Squares[2] = new Square(0, 2, new Bishop(false));
            Squares[3] = new Square(0, 3, new Queen(false));
            Squares[4] = new Square(0, 4, new King(false));
            Squares[5] = new Square(0, 5, new Bishop(false));
            Squares[6] = new Square(0, 6, new Knight(false));
            Squares[7] = new Square(0, 7, new Rook(false));

            Squares[8] = new Square(1, 0, new Pawn(false));
            Squares[9] = new Square(1, 1, new Pawn(false));
            Squares[10] = new Square(1, 2, new Pawn(false));
            Squares[11] = new Square(1, 3, new Pawn(false));
            Squares[12] = new Square(1, 4, new Pawn(false));
            Squares[13] = new Square(1, 5, new Pawn(false));
            Squares[14] = new Square(1, 6, new Pawn(false));
            Squares[15] = new Square(1, 7, new Pawn(false));


            //Initialize white pieces
            Squares[56] = new Square(7, 0, new Rook(true));
            Squares[57] = new Square(7, 1, new Knight(true));
            Squares[58] = new Square(7, 2, new Bishop(true));
            Squares[59] = new Square(7, 3, new Queen(true));
            Squares[60] = new Square(7, 4, new King(true));
            Squares[61] = new Square(7, 5, new Bishop(true));
            Squares[62] = new Square(7, 6, new Knight(true));
            Squares[63] = new Square(7, 7, new Rook(true));

            Squares[55] = new Square(6, 7, new Pawn(true));
            Squares[54] = new Square(6, 6, new Pawn(true));
            Squares[53] = new Square(6, 5, new Pawn(true));
            Squares[52] = new Square(6, 4, new Pawn(true));
            Squares[51] = new Square(6, 3, new Pawn(true));
            Squares[50] = new Square(6, 2, new Pawn(true));
            Squares[49] = new Square(6, 1, new Pawn(true));
            Squares[48] = new Square(6, 0, new Pawn(true));

            //initialize squares without pieces
            int a = 8;
            for (int i = 16; i < 48; i++)
            {
                Squares[i] = new Square(i / a, i % a, null);
            }
        }
    }
}
