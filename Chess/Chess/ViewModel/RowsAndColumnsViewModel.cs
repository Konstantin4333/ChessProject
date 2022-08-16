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
        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            ListView Pieces = new ListView();
            Pieces.Items.Add(Board.Squares);

            TestingRow = 2;
            TestingColumn = 3;

        }
    }

}
