using Chess.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class RowsAndColumnsViewModel:INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int _testingRow;
        private int _testingColumn;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int TestingRow { get { return _testingRow; } set { _testingRow = value; OnPropertyChanged(); } }
        public int TestingColumn { get { return _testingColumn; } set { _testingColumn = value; OnPropertyChanged(); } }

      public Command UpMover { get; set; }
        public Command DownMover { get; set; }
        public Command LeftMover { get; set; }
        public Command RightMover { get; set; }

        public RowsAndColumnsViewModel()
        {
            TestingRow = 5;
            TestingColumn = 3;
            UpMover = new Command(MoveitUp);
            DownMover = new Command(MoveitDown);
            LeftMover = new Command(MoveitLeft);
            RightMover = new Command(MoveitRight);  
        }

        public void MoveitUp(object mover)
        {
            TestingRow--;
        }
        public void MoveitDown(object mover)
        {
            TestingRow++;
        }
        public void MoveitLeft(object mover)
        {
            TestingColumn--;
        }
        public void MoveitRight(object mover)
        {
            TestingColumn++;
        }
    }
    
}
  