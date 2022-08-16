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
    
        private Board _board;
        private Piece _sPiece;
        private Square _square;
        private Square[] _squares;


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
        public Square[] Squares
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
        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            Squares = Board.Squares;
            
        }
    }

}
