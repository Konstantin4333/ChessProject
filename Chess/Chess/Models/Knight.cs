using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Knight : Piece
    {
        public Knight(bool white) : base(white)
        {
            AttachImage(white);
        }
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_knight.png", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_knight.png", UriKind.Relative));
            }
        }

        public override bool CanMove(Square start, Square end)
        {
            return false;
        }

        

        public override List<Square> SelectPath(ObservableCollection<Square> squares, Square start)
        {
               
                List<Square> result = new List<Square>();
            int primary=1;
            int secondary=-2;
            int PieceX, PieceY;
            int c = -1;
            Square currentSquare; 
            for(int i=0;i<4;i++)
            {
                PieceX=start.X;
                PieceY = start.Y;
                PieceX += primary;
                PieceY += secondary;
                if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8) { 
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if(currentSquare.Piece == null || currentSquare.Piece.White != start.Piece.White)
                    result.Add(currentSquare); 
                }
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += secondary;
                PieceY += primary;
                if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece == null || currentSquare.Piece.White!=start.Piece.White)
                        result.Add(currentSquare);
                }
                secondary = secondary * primary * c;
                primary = primary * c;
            }
               return result;
        }
    }
}
