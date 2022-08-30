using Chess.Commands;
using Chess.Helper;
using Chess.Models;
using Chess.View;

using System;
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
        private bool round = true;
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
            foreach(Square sq in _availableMoves)
            {
                sq.IsAvailable=true;
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
                // Visibility.Visible = false;


            }
            else
            {
                App.Current.Windows[0].WindowState = WindowState.Normal;

            }


        }
        public void KingChecker(List<Square> squares, List<Square> AvailableMoves, Piece King)
        {
            List<Square> enemyMoves = new List<Square>();
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
                    if (i >= AvailableMoves.Count) break;
                    SidesChecker(squares, AvailableMoves, King, enemyMoves, primaryRook, secondaryRook, i);
                    primaryRook = primaryRook * c;
                    temporary = primaryRook;
                    primaryRook = secondaryRook;
                    secondaryRook = temporary;
                }
                for (int j = 0; j < 4; j++)
                {
                    if (i >= AvailableMoves.Count) break;
                    SidesChecker(squares, AvailableMoves, King, enemyMoves, primaryBishop, secondaryBishop, i);
                    secondaryBishop = secondaryBishop * primaryBishop * c;
                    primaryBishop = primaryBishop * c;
                }
                for (int j = 0; j < 4; j++)
                {
                    if (i >= AvailableMoves.Count) break;
                    KnightChecker(squares, AvailableMoves, King, enemyMoves, primary, secondary, i);
                    KnightChecker(squares, AvailableMoves, King, enemyMoves, secondary, primary, i);
                    secondary = secondary * primary * c;
                    primary = primary * c;
                }


                if (AvailableMoves.Count == 0) break;
            }

        }

        void SidesChecker(List<Square> squares, List<Square> AvailableMoves, Piece King, List<Square> enemyMoves, int primary, int secondary, int i)
        {
            int PieceX = AvailableMoves[i].X;
            int PieceY = AvailableMoves[i].Y;
            PieceX += primary;
            PieceY += secondary;
            while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquare = squares[PieceX * 8 + PieceY];
                if (currentSquare.Piece != null && currentSquare.Piece.White == King.White) break;
                else if (currentSquare.Piece != null && currentSquare.Piece.White != King.White)
                {
                    enemyMoves = currentSquare.Piece.SelectPath(squares, currentSquare);

                    for (int k = 0; k < AvailableMoves.Count; k++)
                    {
                        if (enemyMoves.Contains(AvailableMoves[k])) { AvailableMoves.RemoveAt(k); k--; }
                    }

                }
                PieceX += primary;
                PieceY += secondary;

            }


        }

        public void KnightChecker(List<Square> squares, List<Square> AvailableMoves, Piece King, List<Square> enemyMoves, int primary, int secondary, int i)
        {

            int PieceX = AvailableMoves[i].X;
            int PieceY = AvailableMoves[i].Y;
            PieceX += primary;
            PieceY += secondary;
            if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquareKnight = squares[PieceX * 8 + PieceY];
                if (currentSquareKnight.Piece != null && currentSquareKnight.Piece.White != King.White)
                {
                    enemyMoves = currentSquareKnight.Piece.SelectPath(squares, currentSquareKnight);

                    for (int k = 0; k < AvailableMoves.Count; k++)
                    {
                        if (enemyMoves.Contains(AvailableMoves[k])) { AvailableMoves.RemoveAt(k); k--; }
                    }
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
                if (SPiece != null && SPiece.White && round == true)
                {

                    _availableMoves = SPiece.SelectPath(Squares, PrevSquare);
                    if (SPiece.GetType() == typeof(King)) { KingChecker(Squares, _availableMoves, SPiece); }
                    
                }
                if (SPiece != null && !SPiece.White && round == false)
                {

                    _availableMoves = SPiece.SelectPath(Squares, PrevSquare);
                    if (SPiece.GetType() == typeof(King)) { KingChecker(Squares, _availableMoves, SPiece); }
                }
                setAvailableSquares();
                _square = null;
            }
            else
            {
                if (_availableMoves.Contains(SelectedSquare))
                {
                    round = !round;
                    SelectedSquare.Piece = SPiece;
                    PrevSquare.Piece = null;
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
        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            Squares = new List<Square>(Board.Squares);
            MoveCommand.AttachImage(Squares);
        }

    }

}


