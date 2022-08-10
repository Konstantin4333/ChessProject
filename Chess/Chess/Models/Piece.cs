using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public abstract class Piece
    {
        private bool killed;
        private bool white;

        public Piece (bool white)
        {
            Killed = false;
            White = white;
        }   

        public bool Killed
        {
            get { return killed; }
            set { killed = value; }
        }
        public bool White 
        { 
            get { return white; }
            set { white = value; }
        }
        public abstract bool canMove(Board board, Square start, Square end);

    }
}
