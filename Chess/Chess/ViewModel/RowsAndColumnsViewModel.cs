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
        private List<Square> test;
        private bool _IsEven;


        public void Move()
        {
            if (SPiece == null)
            {
                SPiece = SelectedSquare.Piece;
                
                PrevSquare = SelectedSquare;
                if(SPiece != null)
                {
                    test = SPiece.SelectPath(Squares, PrevSquare);

                }
                _square = null;
            }
            else
            {
               if(test.Contains(SelectedSquare))
                {
                  //  if (SelectedSquare.Piece == null)
                  //  {
                        SelectedSquare.Piece = SPiece;
                        PrevSquare.Piece = null;
                   //}                     
                    }                     
                test = null;
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

        //--------------------------------------------

      

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
        //--------------------------------------------


        public RowsAndColumnsViewModel()
        {
            Board = new Board();
             Squares = new ObservableCollection<Square>(Board.Squares);

            IsEven = new bool();



        }

    }

}
