using Chess.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chess.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Private properties
        private Board _board;
        private Player _whitePlayer;
        private Player _blackPlayer;
        private Piece _selectedPiece;
        #endregion
       
        public MainViewModel()
        {
            Board = new Board();
            transparency();
           
        }

        private static void transparency()
        {
            if (App.Current.Windows[0].WindowState == WindowState.Normal)
            {
                App.Current.Windows[0].AllowsTransparency = true;
            }else if (App.Current.Windows[0].WindowState == WindowState.Maximized)
            {
                App.Current.Windows[0].AllowsTransparency = false;
            }
        }

        #region public properties

        public Board Board
        {
            get
            {
                return _board;
            } set
            {
                _board = value;
                OnPropertyChanged(nameof(Board));
            }
        }
        public Player WhitePlayer
        {
            get { return _whitePlayer; }
            set { _whitePlayer = value; 
                OnPropertyChanged(nameof(WhitePlayer)); 
            }
        }
        public Player BlackPlayer
        {
            get { return _blackPlayer; }
            set
            {
                _blackPlayer = value;
                OnPropertyChanged(nameof(BlackPlayer));
            }
        }
        public Piece SelectedPiece
        {
            get { return _selectedPiece; }
            set
            {
                _selectedPiece = value;
                OnPropertyChanged(nameof(SelectedPiece));
            }
        }
        #endregion


    }
}
