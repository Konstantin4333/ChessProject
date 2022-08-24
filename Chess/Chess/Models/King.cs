using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Models
{
    public class King : Piece
    {

        public bool castlingDone { get; set; }

        public King(bool white) : base(white)
        {
            castlingDone = false;
            AttachImage(white);
        }
        private void AttachImage(bool white)
        {
            if (white)
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_white_king.png", UriKind.Relative));
            }
            else
            {
                ImageOfPiece = new BitmapImage(new Uri("/Pictures/chess_piece_black_king.png", UriKind.Relative));
            }
        }

        public List<Square> UpPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            x--;

            if (!start.Piece.White)
            {
                if (x >= 0 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {

                        result.Add(sq);


                    }
                    if (sq.Piece == null)
                    {

                        result.Add(sq);

                    }
                }


            }
            else
            {
                if (x >= 0 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {

                        result.Add(sq);

                    }
                }
            }

            return result;
        }
        public List<Square> DownPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            x++;

            if (!start.Piece.White)
            {
                if (x < 8 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {

                        result.Add(sq);


                    }

                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {
                if (x < 8 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {

                        result.Add(sq);

                    }

                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }

            return result;
        }

        public List<Square> LeftPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            y--;

            if (!start.Piece.White)
            {


                if (x >= 0 && y >= 0)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];

                    if (sq.Piece != null && sq.Piece.White)
                    {

                        result.Add(sq);


                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {
                if (x >= 0 && y >= 0)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];

                    if (sq.Piece != null && !sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }

            return result;

        }
        public List<Square> RightPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            y++;

            if (!start.Piece.White)
            {

                if (x >= 0 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {
                if (x >= 0 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }

            return result;

        }
        public List<Square> LeftDownPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            x++;
            y--;

            if (!start.Piece.White)
            {


                if (x < 8 && y >= 0)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {

                if (x < 8 && y >= 0)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            return result;

        }
        public List<Square> RightDownPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            x++;
            y++;

            if (!start.Piece.White)
            {


                if (x < 8 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {

                        result.Add(sq);

                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {
                if (x < 8 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {
                        result.Add(sq);
                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            return result;

        }
        public List<Square> LeftUpPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            x--;
            y--;

            if (!start.Piece.White)
            {


                if (x >= 0 && y >= 0)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {
                        result.Add(sq);
                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {
                if (x >= 0 && y >= 0)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {
                        result.Add(sq);
                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            return result;

        }
        public List<Square> RightUpPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> result = new List<Square>();
            int x = start.X;
            int y = start.Y;

            x--;
            y++;

            if (!start.Piece.White)
            {


                if (x >= 0 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && sq.Piece.White)
                    {
                        result.Add(sq);
                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            else
            {
                if (x >= 0 && y < 8)
                {


                    int index = x * 8 + y;
                    Square sq = squares[index];
                    if (sq.Piece != null && !sq.Piece.White)
                    {
                        result.Add(sq);
                    }
                    if (sq.Piece == null)
                    {
                        result.Add(sq);

                    }
                }
            }
            return result;

        }
        public override List<Square> SelectPath(ObservableCollection<Square> squares, Square start)
        {
            List<Square> up = UpPath(squares, start);
            List<Square> down = DownPath(squares, start);
            List<Square> left = LeftPath(squares, start);
            List<Square> right = RightPath(squares, start);
            List<Square> leftDown = LeftDownPath(squares, start);
            List<Square> rightDown = RightDownPath(squares, start);
            List<Square> leftUp = LeftUpPath(squares, start);
            List<Square> rightUp = RightUpPath(squares, start);
            List<Square> result = new List<Square>();
            result.AddRange(up);
            result.AddRange(down);
            result.AddRange(left);
            result.AddRange(right);
            result.AddRange(leftDown);
            result.AddRange(rightDown);
            result.AddRange(leftUp);
            result.AddRange(rightUp);
            return result;


        }
    }
}