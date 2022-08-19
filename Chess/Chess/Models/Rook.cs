using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override bool CanMove(Board board, Square start, Square end)
        {
            throw new NotImplementedException();
        }

        public override bool CheckPath(ObservableCollection<Square> squares, Square start, Square end)
        {
            throw new NotImplementedException();
        }
    }
}
