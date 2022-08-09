using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Square
    {
        private Piece _piece;
        private int x;
        private int y;
        
        public Square(int x,int y, Piece piece)
        {
            Piece = piece;
            X=x;
            Y=y;
        }
        public Piece Piece
        {
            get { return _piece; }
            set { _piece = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y 
        {
            get { return y; }
            set { y = value; }
        }
        

    }
}
