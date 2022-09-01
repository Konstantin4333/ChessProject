using Chess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media.Imaging;


namespace Chess.Helper
{
    public static class PiecesMovement 
    {
        public static void AttachImage(List<Square> p)
        {
            
            foreach (var sq in p)
            {
               
                if (sq.Piece != null)
                {
                    string type = sq.Piece.GetType().Name.ToString();

                    string color = "";
                    if (sq.Piece.White)
                    {
                         color = "white";
                    }
                    else
                    {
                         color = "black";
                    }
                    string str = $"/Pictures/chess_piece_{color}_{type.ToLower()}.png";

                    sq.Piece.ImageOfPiece = new BitmapImage(new Uri(str, UriKind.Relative));

                }

            }
            
        }
        private static void MoveFiller(List<Square> squares, Square start, List<Square> result, int primary, int secondary)
        {
            int PieceX = start.X;
            int PieceY = start.Y;
            PieceX += primary;
            PieceY += secondary;
            while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
            {
                Square currentSquare = squares[PieceX * 8 + PieceY];
                if (currentSquare.Piece != null && currentSquare.Piece.White == start.Piece.White) break;
                else if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White) { result.Add(currentSquare); break; }
                result.Add(currentSquare);
                PieceX += primary;
                PieceY += secondary;

            }
        }
        public static void  SelectPathKnight(List<Square> squares, List<Square> result, Square start)
        {
            int primary = 1;
            int secondary = -2;
            int PieceX, PieceY;
            int c = -1;
            Square currentSquare;
            for (int i = 0; i < 4; i++)
            {
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += primary;
                PieceY += secondary;
                if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece == null || currentSquare.Piece.White != start.Piece.White)
                        result.Add(currentSquare);
                }
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += secondary;
                PieceY += primary;
                if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece == null || currentSquare.Piece.White != start.Piece.White)
                        result.Add(currentSquare);
                }
                secondary = secondary * primary * c;
                primary = primary * c;
            }
           
        }

        public static List<Square> UpPath(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;


            if (!start.Piece.White)
            {
                x++;


                if (x < 8 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null)
                    {
                        result.Add(sq);
                        if (x == 2)
                        {
                            x++;
                            index = x * 8 + y;
                            Square sq1 = squares[index];
                            if (sq1.Piece == null)
                            {
                                result.Add(sq1);
                            }

                        }
                    }

                }

            }
            else
            {
                x--;
                if (x >= 0 && y >= 0)
                {

                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece == null)
                    {
                        result.Add(sq);
                        if (x == 5)
                        {
                            x--;
                            index = x * 8 + y;
                            Square sq2 = squares[index];
                            if (sq2.Piece == null)
                            {
                                result.Add(sq2);
                            }
                        }
                    }

                }
            }
            return result;
        }
        public static List<Square> SelectPieceMovement(List<Square> Squares ,Piece CurrentPiece, Square start)
        {
            string variable;
            variable = CurrentPiece.GetType().Name.ToString();
            List<Square> AvailableMoves = new List<Square>();
            switch (variable)
            {
                case "King":
                    {
                        SelectPathKing(Squares, AvailableMoves, start);
                      
                    }
                    break;
                case "Queen":
                    {
                        SelectPathBishop(Squares, AvailableMoves, start);
                        SelectPathRook(Squares, AvailableMoves, start);

                    }
                    break;
                case "Bishop":
                    {
                        SelectPathBishop(Squares, AvailableMoves, start);
                    }
                    break;
                case "Rook":
                    {
                        SelectPathRook(Squares, AvailableMoves, start);
                    }
                    break;
                case "Pawn":
                    {
                        SelectPathPawn(Squares, AvailableMoves, start);
                    }
                    break;
                case "Knight":
                    {
                        SelectPathKnight(Squares, AvailableMoves, start);
                    }
                    break;
            }
            return AvailableMoves;
        }
        public static List<Square> Attack(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            Square currentSquare;
            int c = 1;
            if (start.Piece.White == true) c = -1;
            if (start.X + c < 8 && start.X + c >= 0 && start.Y + 1 < 8)
            {

                currentSquare = squares[(start.X + c) * 8 + (start.Y + 1)];
                if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White)
                    result.Add(currentSquare);
            }
            if (start.X + c < 8 && start.X + c >= 0 && start.Y - 1 >=   0)
            {
                currentSquare = squares[(start.X + c) * 8 + (start.Y - 1)];
                if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White)
                    result.Add(currentSquare);
            }

            return result;
        }

        public static void SelectPathPawn(List<Square> squares, List<Square> result, Square start)
        {
            List<Square> up = UpPath(squares, start);
            List<Square> attack = Attack(squares, start);
            result.AddRange(up);
            result.AddRange(attack);


        }
        public static void SelectPathRook(List<Square> squares, List<Square> result, Square start)
        {
            int primary = 1;
            int secondary = 0;
            int c = -1;
            int temporary;
            Square currentSquare;
            for (int i = 0; i < 4; i++)
            {
                MoveFiller(squares, start, result, primary, secondary);

                primary = primary * c;
                temporary = primary;
                primary = secondary;
                secondary = temporary;
            }

            
        }
        public static void SelectPathBishop(List<Square> squares,List<Square> result, Square start)
        {
            int primary = 1;
            int secondary = -1;
            int c = -1;

            for (int i = 0; i < 4; i++)
            {
                MoveFiller(squares, start, result, primary, secondary);

                secondary = secondary * primary * c;
                primary = primary * c;
            }

            
        }
        public static void SelectPathKing(List<Square> squares, List<Square> result, Square start)
        {
            int PieceX, PieceY;
            Square currentSquare;
            for (int i = -1; i < 2; i++)
            {

                for (int j = -1; j < 2; j++)
                {
                    PieceX = start.X;
                    PieceY = start.Y;
                    PieceX += i;
                    PieceY += j;
                    if (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                    {
                        currentSquare = squares[PieceX * 8 + PieceY];
                        if (currentSquare.Piece == null || currentSquare.Piece.White != start.Piece.White) result.Add(currentSquare);
                    }
                }
            }
            
        }

    }
}

