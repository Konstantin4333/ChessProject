
namespace Chess.Models
{
    public class Player
    {

        public int Round { get; set; }
        public bool WhiteSide { get; set; }
        public Player(bool whiteSide)
        {
            WhiteSide = whiteSide;
            Round = 0;
        }
    }
}
