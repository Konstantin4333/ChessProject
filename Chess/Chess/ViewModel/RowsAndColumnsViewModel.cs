 using Chess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Chess.ViewModel
{
    public class RowsAndColumnsViewModel : BaseViewModel
    {
    
        private Board _board;
        private Piece _sPiece;
        
        private Square _square;
       
        private ObservableCollection<Square> _squares;
        private Square _prevSquare;
        private List<Square> _availableMoves;
        
       
        public void Move()
        {
            if (SPiece == null)
            {
                SPiece = SelectedSquare.Piece;
                
                PrevSquare = SelectedSquare;
                if(SPiece != null)
                {
                    _availableMoves = SPiece.SelectPath(Squares, PrevSquare);

                }
               // if (SPiece.ToString() == "King") KingChecker(Squares, _availableMoves, SPiece);
                _square = null;
            }
            else
            {
               if(_availableMoves.Contains(SelectedSquare))
                {
                    SelectedSquare.Piece = SPiece;
                    PrevSquare.Piece = null;                 
                    }                     
                _availableMoves = null;
                SPiece = null;
                _square = null;
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
        public Square PrevSquare
        {
            get { return _prevSquare; }
            set { _prevSquare = value;
                OnPropertyChanged("PrevSquare");

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

        
        

        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            Squares = new ObservableCollection<Square>(Board.Squares);
            
        }

    }

}
