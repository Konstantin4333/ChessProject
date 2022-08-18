﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            AttachImage(white);
        }
        private void AttachImage(bool white)
        {
            if (white)
            {  
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_king.jpg", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_king.jpg", UriKind.Relative));
            }
        }
        public override bool CanMove(Board board, Square start, Square end)
        {
            throw new System.NotImplementedException();
        }

 

        public override List<Square> CheckPath(ObservableCollection<Square> squares, Square start)
        {
            throw new NotImplementedException();
        }
    }
}