using Chess.Models;
using System.Collections.Generic;

namespace Chess.Commands
{
    public interface IMove
    {
        public List<Square> SelectPath(List<Square> squares, Square start);
    }
}
