using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Pawn: Piece
    {
       public Pawn(bool white) : base(white)
        {
            AttachImage(white);
        }
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_pawn.jpg", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_pawn.jpg", UriKind.Relative));
            }
        }
        public override bool CanMove(Board board, Square start, Square end)
        {
            if (end.Piece != null)
            {
                if (end.Piece.White == start.Piece.White)
                {
                    return false;
                }
            }

            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            if (x == y+1)
            {
                return true;
            }


            return false;
        }


        public override List<Square> CheckPath(ObservableCollection<Square> squares, Square start)
        {
            throw new NotImplementedException();
        }
    }
}
