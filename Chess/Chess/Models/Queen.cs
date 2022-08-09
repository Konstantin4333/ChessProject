namespace Chess.Models
{
    public class Queen : Piece
    {
        public Queen(bool white) : base(white)
        {
        }

        public override bool canMove(Board board, Square start, Square end)
        {
            throw new System.NotImplementedException();
        }
    }
}