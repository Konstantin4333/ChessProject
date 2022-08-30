using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chess.Models
{
    public class Square : INotifyPropertyChanged
    {
        private Piece? _piece;
        private int x;
        private int y;
        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            { OnPropertyChanged("IsAvailable"); }
        }
        public Square(int x, int y, Piece piece)
        {
            Piece = piece;
            X = x;
            Y = y;
            IsAvailable = false;
          
        }

        public Piece Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                OnPropertyChanged("Piece");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
