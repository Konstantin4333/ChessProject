namespace Chess.Models
{
    public class King : Piece
    {
        public King(bool white) : base(white)
        {
        }

        public override bool canMove(Board board, Square start, Square end)
        {
            throw new System.NotImplementedException();
        }
    }
}