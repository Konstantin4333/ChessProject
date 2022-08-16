using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class King : Piece
    {
        
        public bool castlingDone { get; set; }
        
        public King(bool white) : base(white)
        {
            castlingDone = false;
            ImageOfPiece = new BitmapImage(new Uri("C:\\Users\\Administrator\\source\\repos\\ChessProjects\\Chess\\Chess\\Pictures\\chess_piece_black_bishop.jpg", UriKind.Absolute));
        }
        
        public override bool CanMove(Board board, Square start, Square end)
        {
            throw new System.NotImplementedException();
        }
    }
}