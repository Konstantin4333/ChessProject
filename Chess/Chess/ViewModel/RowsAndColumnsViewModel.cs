 using Chess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Prism.Commands;
using Chess.View;

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
                return _minimize ?? (_minimize = new DelegateCommand(() =>
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
                return _closeApp ?? (_closeApp = new DelegateCommand(() =>
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

                    }
                    else
                    {
                        App.Current.Windows[0].WindowState = WindowState.Normal;
                    }

                }));
            }
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
             Squares = new ObservableCollection<Square>(Board.Squares);

            IsEven = new bool();



        }

    }

}
