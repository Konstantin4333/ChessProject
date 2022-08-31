using Chess.Models;
using Chess.View;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;


namespace Chess.Helper
{
    public static class MoveCommand
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
                    String str = $"/Pictures/chess_piece_{color}_{type.ToLower()}.png";
                    sq.Piece.ImageOfPiece = new BitmapImage(new Uri(str, UriKind.Relative));
                }
            }
        }
        public static List<Square> SelectPath(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            List<Square> AvailableMoves = new List<Square>();
            Piece King = new Piece();


            {
                if (start.Piece != null)
                {
                    String type = start.Piece.GetType().Name.ToString();
                    switch (type)
                    {
                        case "Bishop":
                            return SelectBishopPath(squares, start, result);
                            break;

                        case "King":
                            KingChecker(squares, AvailableMoves, King);
                            SelectKingPath(squares, start, result);
                            break;
                        case "Knight":
                            SelectKnightPath(squares, start, result);
                            break;
                        case "Queen":
                            SelectQueenPath(squares, start, result);
                            break;
                        case "Pawn":
                            SelectPawnPath(squares, start, result);
                            break;
                        case "Rook":
                            SelectRookPath(squares, start, result);
                            break;
                    }
                }
            }
            return result;
        }
        public static List<Square> SelectBishopPath(List<Square> squares, Square start, List<Square> result)
        {
            foreach (var square in squares)
            {
                if (square.Piece != null)
                {
                    string type = square.Piece.GetType().Name.ToString();
                    if (type.Equals("Bishop"))
                    {
                        int primary = 1;
                        int secondary = -1;
                        int PieceX, PieceY;
                        int c = -1;
                        Square currentSquare;
                        for (int i = 0; i < 4; i++)
                        {
                            PieceX = start.X;
                            PieceY = start.Y;
                            PieceX += primary;
                            PieceY += secondary;
                            while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                            {
                                currentSquare = squares[PieceX * 8 + PieceY];
                                if (currentSquare.Piece != null && currentSquare.Piece.White == start.Piece.White) break;
                                else if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White) { result.Add(currentSquare); break; }
                                result.Add(currentSquare);
                                PieceX += primary;
                                PieceY += secondary;
                            }
                            secondary = secondary * primary * c;
                            primary = primary * c;
                        }
                    }
                }
            }
            return result;
        }
        public static List<Square> SelectKingPath(List<Square> squares, Square start, List<Square> result)
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
            return result;
        }
        public static List<Square> SelectKnightPath(List<Square> squares, Square start, List<Square> result)
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
            return result;
        }
        public static List<Square> SelectQueenPath(List<Square> squares, Square start, List<Square> result)
        {
            int primary = 1;
            int secondary = -1;
            int PieceX, PieceY;
            int c = -1;
            Square currentSquare;
            int temporary;
            for (int i = 0; i < 4; i++)
            {
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += primary;
                PieceY += secondary;
                while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece != null && currentSquare.Piece.White == start.Piece.White) break;
                    else if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White) { result.Add(currentSquare); break; }
                    result.Add(currentSquare);
                    PieceX += primary;
                    PieceY += secondary;

                }
                secondary = secondary * primary * c;
                primary = primary * c;
            }
            primary = 1;
            secondary = 0;
            for (int i = 0; i < 4; i++)
            {
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += primary;
                PieceY += secondary;
                while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece != null && currentSquare.Piece.White == start.Piece.White) break;
                    else if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White) { result.Add(currentSquare); break; }
                    result.Add(currentSquare);
                    PieceX += primary;
                    PieceY += secondary;
                }
                primary = primary * c;
                temporary = primary;
                primary = secondary;
                secondary = temporary;
            }
            return result;
        }
        public static List<Square> SelectRookPath(List<Square> squares, Square start, List<Square> result)
        {
            int primary = 1;
            int secondary = 0;
            int PieceX, PieceY;
            int c = -1;
            int temporary;
            Square currentSquare;
            for (int i = 0; i < 4; i++)
            {
                PieceX = start.X;
                PieceY = start.Y;
                PieceX += primary;
                PieceY += secondary;
                while (PieceX >= 0 && PieceY >= 0 && PieceX < 8 && PieceY < 8)
                {
                    currentSquare = squares[PieceX * 8 + PieceY];
                    if (currentSquare.Piece != null && currentSquare.Piece.White == start.Piece.White) break;
                    else if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White) { result.Add(currentSquare); break; }
                    result.Add(currentSquare);
                    PieceX += primary;
                    PieceY += secondary;
                }
                primary = primary * c;
                temporary = primary;
                primary = secondary;
                secondary = temporary;
            }
            return result;
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
                    }
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
                    }
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
            return result;
        }
        public static List<Square> Attack(List<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            Square currentSquare;
            int c = 1;
            if (start.Piece.White == true) c = -1;
            if (start.X + c < 8 && start.X + c > 0 && start.Y + 1 < 8)
            {
                currentSquare = squares[(start.X + c) * 8 + (start.Y + 1)];
                if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White)
                {
                    result.Add(currentSquare);
                }
            }
            if (start.X + c < 8 && start.X + c > 0 && start.Y - 1 >= 0)
            {
                currentSquare = squares[(start.X + c) * 8 + (start.Y - 1)];
                if (currentSquare.Piece != null && currentSquare.Piece.White != start.Piece.White)
                    result.Add(currentSquare);
            }
            return result;
        }
        public static List<Square> SelectPawnPath(List<Square> squares, Square start, List<Square> result)
        {
            List<Square> up = UpPath(squares, start);
            List<Square> attack = Attack(squares, start);
            result.AddRange(up);
            result.AddRange(attack);
            return result;
        }
        public static void KingChecker(List<Square> squares, List<Square> AvailableMoves, Piece King)
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
        public static void SidesChecker(List<Square> squares, List<Square> AvailableMoves, Piece King, List<Square> enemyMoves, int primary, int secondary, int i)
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
        public static void KnightChecker(List<Square> squares, List<Square> AvailableMoves, Piece King, List<Square> enemyMoves, int primary, int secondary, int i)
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
    }
}


 



