using System;
using System.Collections.Generic;
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
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_knight.jpg", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_knight.jpg", UriKind.Relative));
            }
        }

        public override bool CanMove(Board board, Square start, Square end)
        {
            throw new NotImplementedException();
        }
    }
}
