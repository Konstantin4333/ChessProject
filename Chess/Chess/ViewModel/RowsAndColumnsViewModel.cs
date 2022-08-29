using Chess.Helper;
using Chess.Models;
using Chess.View;
using Prism.Commands;
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

        private Board _board;
        private Piece _sPiece;
        private Square _square;
        private List<Square> _squares;
        private Square _prevSquare;
        private List<Square> _availableMoves;
        private bool round = true;
        private bool _IsEven;

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



        //--------------------------------------------



        #region Border
        private DelegateCommand _closeApp;
        private DelegateCommand _minimize;

        private DelegateCommand _resize;
        private DelegateCommand _windowTest;
        private DelegateCommand _resetApp;
        private DelegateCommand _deathZone;




        bool isOpened = false;





        public ICommand CloseApp
        {
            get
            {
                return _closeApp ?? (_closeApp = new DelegateCommand(() =>
                {
                    App.Current.Shutdown();
                }));
            }
        }


        public ICommand ResetApp
        {
            get
            {
                return _resetApp ?? (_resetApp = new DelegateCommand(() =>
                {
                    var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
                    Process.Start(currentExecutablePath);
                    App.Current.Shutdown();

                }));
            }
        }

        public ICommand Minimize
        {
            get
            {
                return _minimize ?? (_minimize = new DelegateCommand(() =>
                {
                    App.Current.Windows[0].WindowState = WindowState.Minimized;
                }));
            }
        }


        public ICommand WindowTest
        {
            get
            {
                return _windowTest ?? (_windowTest = new DelegateCommand(() =>
                {
                    //*App.Current.Windows[0].WindowState = WindowState.Minimized;*//*


                    UserControls.Add(GetUserControlInstance("DeathZone"));


                }));
            }
        }

        public ICommand DeathZonecmd
        {
            get
            {
                return _deathZone ?? (_deathZone = new DelegateCommand(() =>
                {
                    UserControl userControl = new DeathZonePieces();
                    UserControls.Add(userControl);
                    userControl.BringIntoView();

                }));
            }
        }



        public ICommand Resize
        {
            get
            {
                return _resize ?? (_resize = new DelegateCommand(() =>
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

                }));
            }
        }

        private Visibility _MessageVisibilty;
        public Visibility MessageVisibilty
        {
            get { return _MessageVisibilty; }
            set { SetProperty(ref _MessageVisibilty, value); }
        }

        private void SetProperty(ref Visibility messageVisibilty, Visibility value)
        {
            MessageVisibilty = Visibility.Hidden;
        }

        public ObservableCollection<FrameworkElement> UserControls { get; set; } = new ObservableCollection<FrameworkElement>();
        public void Execute(object? parameter)
        {
            // UserControls.Clear();
            switch (parameter?.ToString())
            {
                case "DeathZone":
                    UserControls.Add(GetUserControlInstance("DeathZone"));
                    break;

                default:
                    break;
            }
        }

        private FrameworkElement GetUserControlInstance(string v)
        {
            throw new NotImplementedException();
        }
        #endregion

        

        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            Squares = new List<Square>(Board.Squares);
            IsEven = new bool();
            MoveCommand.AttachImage(Squares);
        }

    }

}


