using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class King : Piece
    {

        public bool castlingDone { get; set; }

        public King(bool white) : base(white)
        {
            castlingDone = false;
        }
     
        public override List<Square> SelectPath(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int PieceX, PieceY;
            Square currentSquare;
            for (int i = -1; i < 2; i++)
            {

                for (int j = -1; j < 2; j++)
                {
                    PieceX = start.X;
                    PieceY = start.Y;
                    PieceX += i;
                    PieceY += j;
                    if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                    {
                        currentSquare = squares[PieceX * 8 + PieceY];
                        if (currentSquare.Piece == null || currentSquare.Piece.White != start.Piece.White) result.Add(currentSquare);
                    }
                }
            }
            return result;
        }
    }
}