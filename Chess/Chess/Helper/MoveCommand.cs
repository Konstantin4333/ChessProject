using Chess.Models;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;


namespace Chess.Helper
{
    public static class MoveCommand 
    {
        

        
       // public ImageSource ImageOfPiece { get; set; }
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
           /* foreach (var square in squares)
            {
                if(square.Piece != null)
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
*/
            return result;
        }
    }
}

