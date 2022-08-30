using Chess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private bool round = true;

        

        public void KingChecker(ObservableCollection<Square> squares, List<Square> AvailableMoves, Piece King)
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

        void SidesChecker(ObservableCollection<Square> squares, List<Square> AvailableMoves, Piece King, List<Square> enemyMoves, int primary, int secondary, int i)
        {
            int PieceX = AvailableMoves[i].X;
            int PieceY = AvailableMoves[i].Y;
            PieceX += primary;
            PieceY += secondary;
            Square pawn;
            while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquare = squares[PieceX * 8 + PieceY];
                if (currentSquare.Piece != null && currentSquare.Piece.White == King.White) break;
                else if (currentSquare.Piece != null && currentSquare.Piece.White != King.White)
                {
                    if (currentSquare.Piece.GetType() == typeof(Pawn))
                    {
                        enemyMoves = PawnChecker(squares, enemyMoves, currentSquare);

                    }
                    else
                    {
                        enemyMoves = currentSquare.Piece.SelectPath(squares, currentSquare);
                    }
                        for (int k = 0; k < AvailableMoves.Count; k++)
                        {
                            if (enemyMoves.Contains(AvailableMoves[k])) { AvailableMoves.RemoveAt(k); k--; }
                        }
                    
                }
                PieceX += primary;
                PieceY += secondary;

            }


        }

 

        public void KnightChecker(ObservableCollection<Square> squares, List<Square> AvailableMoves, Piece King, List<Square> enemyMoves, int primary, int secondary, int i)
        {

            int PieceX = AvailableMoves[i].X;
            int PieceY = AvailableMoves[i].Y;
            PieceX += primary;
            PieceY += secondary;
            Square pawn;
            if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquareKnight = squares[PieceX * 8 + PieceY];
                if (currentSquareKnight.Piece != null && currentSquareKnight.Piece.White != King.White)
                {
                    if (currentSquareKnight.Piece.GetType() == typeof(Pawn))
                    {
                        enemyMoves = PawnChecker(squares, enemyMoves, currentSquareKnight);
                    }
                    else
                    {

                        enemyMoves = currentSquareKnight.Piece.SelectPath(squares, currentSquareKnight);
                        for (int k = 0; k < AvailableMoves.Count; k++)
                        {
                            if (enemyMoves.Contains(AvailableMoves[k])) { AvailableMoves.RemoveAt(k); k--; }
                        }
                    }
                    }
                }


            
        }

        private static List<Square> PawnChecker(ObservableCollection<Square> squares, List<Square> enemyMoves, Square currentSquare)
        {
            Square pawn;
            enemyMoves.Clear();
            int c = 1;
            if (currentSquare.Piece.White == true) c = -1;
            if (currentSquare.X + c < 8 && currentSquare.X + c > 0 && currentSquare.Y + 1 < 8)
            {

                pawn = squares[(currentSquare.X + c) * 8 + (currentSquare.Y + 1)];
                if (pawn.Piece == null)
                    enemyMoves.Add(pawn);
            }
            if (currentSquare.X + c < 8 && currentSquare.X + c > 0 && currentSquare.Y - 1 > 0)
            {
                pawn = squares[(currentSquare.X + c) * 8 + (currentSquare.Y - 1)];
                if (pawn.Piece == null)
                    enemyMoves.Add(pawn);
            }

            return enemyMoves;
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
        public ObservableCollection<Square> Squares
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




        public RowsAndColumnsViewModel()
        {
            Board = new Board();
            Squares = new ObservableCollection<Square>(Board.Squares);

        }

    }

}
