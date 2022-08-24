using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Rook : Piece
    {
        public Rook(bool white) : base(white)
        {
            AttachImage(white);
        }
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_rook.png", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_rook.png", UriKind.Relative));
            }
        }

        public override List<Square> SelectPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int primary = 1;
            int secondary = 0;
            int PieceX, PieceY;
            int c = -1;
            int temporary;
            Square currentSquare;
            for (int i = 0; i < 4; i++)
            {
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += primary;
                PieceY += secondary;
                while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece != null && currentSquare.Piece.White == start.Piece.White) break;
                    else if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White) { result.Add(currentSquare); break; }
                    result.Add(currentSquare);
                    PieceX += primary;
                    PieceY += secondary;

                }

                primary = primary * c;
                temporary = primary;
                primary = secondary;
                secondary = temporary;
            }

            return result;
        }
    }
}
