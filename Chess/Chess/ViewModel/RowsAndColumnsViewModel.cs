using Chess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.ViewModel
{
    public class RowsAndColumnsViewModel : BaseViewModel
    {
        public int TestingRow { get; set; }
        public int TestingColumn { get; set; }
        private Board _board;
        private bool _IsEven;
        public Board Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }

        public bool IsEven
        {
            get { return _IsEven; }
            set
            {
                _IsEven = value;
                OnPropertyChanged(nameof(IsEven));
            }
        }
        public void CheckSquareEvent(Square[] sq)
        {

            // Squares = new Square[64];
            for (int i = 0; i < 64; i++)
            {
                if (i % 2 == 0)
                {
                    sq[i].IsEven = true;

                }

            }
            Console.WriteLine();

        }

        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            IsEven = new bool();
          
           

          
        }
    }

}
