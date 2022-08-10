using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Board
    {
        public Square[][] Squares { get; set; }
        

        public Board()
        {
            this.resetBoard();
        }
        public Square getSquare(int x, int y)
        {
            if(x < 0 || x > 7 || y < 0 || y > 7) {
                throw new Exception("Index out of bounds");
            }

            return Squares[x][y];
        }
        public void resetBoard()
        {
            //Initialize white pieces 
            Squares[0][0] = new Square(0, 0, new Rook(false));
            Squares[0][1] = new Square(0, 1, new Knight(false));
            Squares[0][2] = new Square(0, 2, new Bishop(false));
            Squares[0][3] = new Square(0, 3, new Queen(false));
            Squares[0][4] = new Square(0, 4, new King(false));
            Squares[0][5] = new Square(0, 5, new Bishop(false));
            Squares[0][6] = new Square(0, 6, new Knight(false));
            Squares[0][7] = new Square(0, 7, new Rook(false));

            Squares[1][0] = new Square(1, 0, new Pawn(false));
            Squares[1][1] = new Square(1, 1, new Pawn(false));
            Squares[1][2] = new Square(1, 2, new Pawn(false));
            Squares[1][3] = new Square(1, 3, new Pawn(false)); 
            Squares[1][4] = new Square(1, 4, new Pawn(false));
            Squares[1][5] = new Square(1, 5, new Pawn(false));
            Squares[1][6] = new Square(1, 6, new Pawn(false));
            Squares[1][7] = new Square(1, 7, new Pawn(false));


            //Initialize black pieces
            Squares[7][0] = new Square(0, 0, new Rook(true));
            Squares[7][1] = new Square(0, 1, new Knight(true));
            Squares[7][2] = new Square(0, 2, new Bishop(true));
            Squares[7][3] = new Square(0, 3, new Queen(true));
            Squares[7][4] = new Square(0, 4, new King(true));
            Squares[7][5] = new Square(0, 5, new Bishop(true));
            Squares[7][6] = new Square(0, 6, new Knight(true));
            Squares[7][7] = new Square(0, 7, new Rook(true));

            Squares[6][0] = new Square(1, 0, new Pawn(true));
            Squares[6][1] = new Square(1, 1, new Pawn(true));
            Squares[6][2] = new Square(1, 2, new Pawn(true));
            Squares[6][3] = new Square(1, 3, new Pawn(true));
            Squares[6][4] = new Square(1, 4, new Pawn(true));
            Squares[6][5] = new Square(1, 5, new Pawn(true));
            Squares[6][6] = new Square(1, 6, new Pawn(true));
            Squares[6][7] = new Square(1, 7, new Pawn(true));

            //initialize squares without pieces
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Squares[i][j] = new Square(i, j, null);
                }
            }
        }
    }
}
