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
            return null;
        }
    }
}