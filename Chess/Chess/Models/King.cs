namespace Chess.Models
{
    public class King : Piece
    {
        public bool castlingDone { get; set; }

        public King(bool white) : base(white)
        {
            castlingDone = false;
        }

        public override bool canMove(Board board, Square start, Square end)
        {
            throw new System.NotImplementedException();
        }
    }
}