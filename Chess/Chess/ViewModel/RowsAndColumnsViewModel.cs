using Chess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chess.ViewModel
{
    public class RowsAndColumnsViewModel : BaseViewModel
    {
    
        private Board _board;
        private Piece _sPiece;
        private bool _IsEven;
        private Square _square;
       
        private ObservableCollection<Square> _squares;
        

        public void Move()
        {
            if (SPiece == null)
            {
                SPiece = SelectedSquare.Piece;

                SelectedSquare.Piece = null;


            }
            else
            {
                if (SelectedSquare.Piece == null)
                    SelectedSquare.Piece = SPiece;
                    SPiece = null; 
            }
        }
        
        public Square SelectedSquare
        {
            get { return _square; }
            set { _square = value;
               
               
                
                Move();
                OnPropertyChanged("SelectedSquare");
            }

        }

        public Piece SPiece
        {
            get { return _sPiece; }
            set {
                _sPiece = value;
                
                OnPropertyChanged("SPiece");

            }
            
        }
        public ObservableCollection<Square> Squares
        {
            get { return _squares; }
            set { _squares = value;
            OnPropertyChanged("Squares");
            }
        }
        public Board Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
                OnPropertyChanged("Board");
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
            Squares = new ObservableCollection<Square>(Board.Squares);
            
            IsEven = new bool();
          

          
        }
    }

}
