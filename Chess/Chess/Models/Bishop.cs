using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class Bishop : Piece
    {
       
        public Bishop(bool white) : base(white)
        {
            AttachImage(white);

        }
        
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_bishop.png", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_bishop.png", UriKind.Relative));
            }
        }
        
        public override List<Square> SelectPath(ObservableCollection<Square> squares, Square start)
            {
            List<Square> result = new List<Square>();
            int x = 1;
            int y = -1;
            int Px, Py;
            int c = -1;
            Square sq;
            for(int i=0;i<4;i++)
            {
                Px = start.X;
                Py = start.Y;
                Px += x;
                Py += y;
                while (Px >= 0 && Py >= 0 && Px < 8 && Py < 8)
                {
                    sq = squares[Px * 8 + Py];
                    if (sq.Piece != null && sq.Piece.White == start.Piece.White) break;
                    else if (sq.Piece != null && sq.Piece.White != start.Piece.White) { result.Add(sq); break; }
                        result.Add(sq);      
                    Px += x;
                    Py += y;

                }

                y = y * x * c;
                x = x * c;
                }

            return result;
        }
        }
    }
