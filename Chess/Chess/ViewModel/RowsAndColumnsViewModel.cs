using Chess.Commands;
using Chess.Helper;
using Chess.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class RowsAndColumnsViewModel : BaseViewModel
    {
        #region Private fields
        private Board _board;
        private Piece _sPiece;
        private Square _square;
        private List<Square> _squares;
        private Square _prevSquare;
        private List<Square> _availableMoves;
       
        private ICommand _closeApp;
        private ICommand _resetApp;
        private ICommand _resize;
        private ICommand _minimize;
        #endregion
        #region Commands
        public ICommand CloseApp
        {
            get { return _closeApp ?? (_closeApp = new Command(p => true, p => Shutdown())); }
        }
        public ICommand ResetApp
        {
            get { return _resetApp ?? (_resetApp = new Command(p => true, p => Reset())); }
        }
        public ICommand Resize
        {
            get
            {
                return _resize ?? (_resize = new Command(p => true, p => ResizeAction()));
            }
        }
        public ICommand Minimize
        {
            get
            {
                return _minimize ?? (_minimize = new Command(p => true, p => MinimizeAction()));
            }
        }
        #endregion
        #region Methods
        public void setAvailableSquares()
        {
            foreach(Square sq in AvailableMoves)
            {
                sq.IsAvailable=true;
            }
        }
        public void clearAvailableSquares()
        {
            foreach (Square sq in AvailableMoves)
            {
                sq.IsAvailable = false;
            }
        }
        private void Shutdown()
        {
            App.Current.Shutdown();
        }
        private void MinimizeAction()
        {
            App.Current.Windows[0].WindowState = WindowState.Minimized;
        }
        private void Reset()
        {
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            App.Current.Shutdown();
        }
        private void ResizeAction()
        {

            if (App.Current.Windows[0].WindowState == WindowState.Normal)
            {

                App.Current.Windows[0].WindowState = WindowState.Maximized;
                Button button = new Button();
               

            }
            else
            {
                App.Current.Windows[0].WindowState = WindowState.Normal;

            }


        }
        
        public void KingChecker(List<Square> AvailableMoves, Piece King)
        {
            int primaryRook = 1;
            int secondaryRook = 0;
            int primaryBishop = 1;
            int secondaryBishop = -1;
            int primary = 1;
            int secondary = -2;
            int c = -1;
            int temporary;
            for (int i = 0; i < AvailableMoves.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                   
                    if (i > AvailableMoves.Count || i<0) break;
                    i=SidesChecker( AvailableMoves, King, primaryRook, secondaryRook, i);
                    primaryRook = primaryRook * c;
                    temporary = primaryRook;
                    primaryRook = secondaryRook;
                    secondaryRook = temporary;
                    if (i > AvailableMoves.Count || i < 0) break;
                    i =SidesChecker(AvailableMoves, King, primaryBishop, secondaryBishop, i);            
                    secondaryBishop = secondaryBishop * primaryBishop * c;
                    primaryBishop = primaryBishop * c;
                    if (i > AvailableMoves.Count || i < 0 ) break;
                    i =KnightChecker( AvailableMoves, King, primary, secondary, i);
                    if (i > AvailableMoves.Count || i < 0) break;
                    i =KnightChecker( AvailableMoves, King, secondary, primary, i);
                    secondary = secondary * primary * c;
                    primary = primary * c;
                }

            }

        }

        public int SidesChecker(List<Square> AvailableMoves, Piece King, int primary, int secondary, int i)
        {
            List<Square> enemyMoves = new List<Square>();
            int PieceX = AvailableMoves[i].X;
            int PieceY = AvailableMoves[i].Y;
            PieceX += primary;
            PieceY += secondary;
            while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquare = Squares[PieceX * 8 + PieceY];
                if (currentSquare.Piece != null && currentSquare.Piece.White == King.White) break;
                 if (currentSquare.Piece != null && currentSquare.Piece.White != King.White)
                {
                   if (currentSquare.Piece.GetType() == typeof(Pawn))
                    {
                        enemyMoves = PawnChecker(Squares, enemyMoves, currentSquare);

                    }
                    else
                    {
                        enemyMoves =PiecesMovement.SelectPieceMovement(Squares,currentSquare.Piece,currentSquare);
                   }
                    for (int k = 0; k < AvailableMoves.Count; k++)
                    {
                        if (enemyMoves.Contains(AvailableMoves[k])) { AvailableMoves.RemoveAt(k); k--;if(i>=0)i--; }
                    }

                }
                PieceX += primary;
                PieceY += secondary;

            }

            return i;
        }

        public int KnightChecker(List<Square> AvailableMoves, Piece King, int primary, int secondary, int i)
        {
            List<Square> enemyMoves=new List<Square>();
            int PieceX = AvailableMoves[i].X;
            int PieceY = AvailableMoves[i].Y;
            PieceX += primary;
            PieceY += secondary;
            if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquareKnight = Squares[PieceX * 8 + PieceY];
                if (currentSquareKnight.Piece != null && currentSquareKnight.Piece.White != King.White)
                {
                    if (currentSquareKnight.Piece.GetType() == typeof(Pawn))
                    {
                        enemyMoves = PawnChecker(Squares, enemyMoves, currentSquareKnight);
                    }
                    else
                    {
                        enemyMoves = PiecesMovement.SelectPieceMovement(Squares, currentSquareKnight.Piece, currentSquareKnight);
                    }
                        for (int k = 0; k < AvailableMoves.Count; k++)
                        {
                            if (enemyMoves.Contains(AvailableMoves[k])) { AvailableMoves.RemoveAt(k); k--; if (i >= 0) i--; }
                        }
                    
                }
            }

            return i;

        }

        private  List<Square> PawnChecker(List<Square> squares, List<Square> enemyMoves, Square currentSquare)
        {
            enemyMoves.Clear();
            Square pawnAttack;
            int c = 1;
            if (currentSquare.Piece.White == true) c = -1;
            if (currentSquare.X + c < 8 && currentSquare.X + c >= 0 && currentSquare.Y + 1 < 8)
            {

                pawnAttack = squares[(currentSquare.X + c) * 8 + (currentSquare.Y + 1)];
                if (pawnAttack.Piece == null)
                    enemyMoves.Add(pawnAttack);
            }
            if (currentSquare.X + c < 8 && currentSquare.X + c >= 0 && currentSquare.Y - 1 >= 0)
            {
                pawnAttack = squares[(currentSquare.X + c) * 8 + (currentSquare.Y - 1)];
                if (pawnAttack.Piece == null)
                    enemyMoves.Add(pawnAttack);
            }

            return enemyMoves;
        }
        public void Checkmate(List<Square> availableMoves, Piece attackingPiece)
        {
            bool checkmate = false;
            List<Square> kingMoves=new List<Square>();
            for(int i=0;i<availableMoves.Count; i++)
            {
                if (availableMoves[i].Piece!=null && availableMoves[i].Piece.GetType() == typeof(King) && availableMoves[i].Piece.White != attackingPiece.White)
                {
                    kingMoves = PiecesMovement.SelectPieceMovement(Squares, availableMoves[i].Piece, availableMoves[i]);
                    KingChecker(kingMoves, availableMoves[i].Piece);
                    if (kingMoves.Count > 0) MessageBox.Show("Check");
                    else MessageBox.Show("Checkmate\n YOU WIN");
                }
            }
            
        }
    
        public void Move()
        {
            

            if (SPiece == null)
            {
                SPiece = SelectedSquare.Piece;

                PrevSquare = SelectedSquare;
                _availableMoves = new List<Square>();
               if (SPiece != null && SPiece.White && Round == true)
                {
                _availableMoves = PiecesMovement.SelectPieceMovement(Squares,SPiece,PrevSquare);
                    
               if (SPiece.GetType() == typeof(King)) { KingChecker( _availableMoves, SPiece); }
                 }
                      if (SPiece != null && !SPiece.White && Round == false)
                      {
                       _availableMoves = PiecesMovement.SelectPieceMovement(Squares, SPiece, PrevSquare);
                   
                   if (SPiece.GetType() == typeof(King)) { KingChecker( _availableMoves, SPiece); }
                   }
                setAvailableSquares();
                _square = null;
                
            }
            else
            {
                if (_availableMoves.Contains(SelectedSquare))
                {   Round = !Round;

                    SelectedSquare.Piece = SPiece;

                    PrevSquare.Piece = null;
                    
               
                }
                
              clearAvailableSquares();
                if (SelectedSquare.Piece != null)
                {
                    _availableMoves = PiecesMovement.SelectPieceMovement(Squares, SPiece, SelectedSquare);
                    Checkmate(_availableMoves, SPiece);
                    clearAvailableSquares();
                }
                _availableMoves = null;
                SPiece = null;
                _square = null;
            }
        }
        #endregion
        #region public Fields
        public Square SelectedSquare
        {
            get { return _square; }
            set
            {
                _square = value;


                Move();
                OnPropertyChanged("SelectedSquare");
            }

        }

        public Piece SPiece
        {
            get { return _sPiece; }
            set
            {
                _sPiece = value;

                OnPropertyChanged("SPiece");

            }

        }
        public Square PrevSquare
        {
            get { return _prevSquare; }
            set
            {
                _prevSquare = value;
                OnPropertyChanged("PrevSquare");

            }
        }
        public List<Square> Squares
        {
            get { return _squares; }
            set
            {
                _squares = value;
                OnPropertyChanged("Squares");
            }
        }
        public List<Square> AvailableMoves
        {
            get { return _availableMoves; }
            set
            {
                _availableMoves = value; OnPropertyChanged("AvailableMoves");
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
        #endregion

        private bool isResize;
        public bool IsResize
        {
            get { return isResize; }
            set { isResize = value; 
            OnPropertyChanged("IsResize");}
        }
        private int roundCount = 0;
        public int RoundCount
        {
            get { return roundCount; }
            set
            {
                roundCount = value;
                
                OnPropertyChanged("RoundCount");
            }
        }

        private bool round = true;
        public bool Round
        {
            get { return round; }
            set
            {
                round = value;
                RoundCount++;
                OnPropertyChanged("Round");
            }
        }

        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            Squares = new List<Square>(Board.Squares);
            PiecesMovement.AttachImage(Squares);
        }
    }

}


