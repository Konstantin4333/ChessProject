using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models
{
    public class Rook : Piece
    {
        public Rook(bool white) : base(white)
        {

        }

        public override bool CanMove(Board board, Square start, Square end)
        {
            throw new NotImplementedException();
        }
    }
}
