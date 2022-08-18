using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Queen : Piece
    {
        public Queen(bool white) : base(white)
        {
            AttachImage(white);
        }
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_queen.jpg", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_queen.jpg", UriKind.Relative));
            }
        }
        public override bool CanMove( Square start, Square end)
        {
            throw new System.NotImplementedException();
        }

       

        public override List<Square> CheckPath(ObservableCollection<Square> squares, Square start)
        {
            throw new NotImplementedException();
        }
    }
}