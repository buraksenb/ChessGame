using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King : CommonProperties
    {
        Check Rookcheck = new Check();
        public bool isMovable(GameBoard _Game, Coordinate _Next)
        {

            bool foechecker;
            bool foeTester;
            if (IsWhite)
            {
                if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")))
                {
                    foechecker = !(_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                    foeTester = (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty") || foechecker);
                }
                else
                {
                    foeTester = _Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty");
                }
            }
            else
            {
                if (!(_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty")))
                {
                    foechecker = (_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                    foeTester = (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty") || foechecker);
                }
                else
                {
                    foeTester = _Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty");
                }
            }
            sbyte distanceX = (sbyte)Math.Abs(Current.X - _Next.X);
            sbyte distanceY = (sbyte)Math.Abs(Current.Y - _Next.Y);
            float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            if ((distance < 2 && distance > 0) && foeTester)
            {
                didMove = true;
                return true;
            }




            return false;
        }
       
        public bool Rooktest1(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            if (!(whoseturn ^ IsWhite))
            {
                bool foechecker;
                if (IsWhite)
                {
                    foechecker = !(_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                }
                else
                {
                    foechecker = (_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                }

                if ((didMove == false) && ((_Current.X == 0) || _Current.X == 7) && (_Current.Y == 4))
                {
                    byte cX;
                    if (IsWhite)
                    {
                        cX = 0;
                    }
                    else
                    {
                        cX = 7;
                    }
                    if ((_Next.Y == 6) && _Game.Chessboard[cX, 7].GetType().ToString().Contains("Castle") && !(_Game.Chessboard[cX, 7].didMove) && _Game.Chessboard[cX, 6].GetType().ToString().Contains("Empty") && _Game.Chessboard[cX, 5].GetType().ToString().Contains("Empty") && Rookcheck.ChecktestforRook(_Game, _Current, cX, 5) && Rookcheck.ChecktestforRook(_Game, _Current, cX, 6))
                    {
                        return true;

                    }

                }
            }
            return false; 
        }
        
        public bool Rooktest2(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            if (!(whoseturn ^ IsWhite))
            {
                bool foechecker;
                if (IsWhite)
                {
                    foechecker = !(_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                }
                else
                {
                    foechecker = (_Game.Chessboard[_Next.X, _Next.Y].IsWhite);
                }

                if ((didMove == false) && ((_Current.X == 0) || _Current.X == 7) && (_Current.Y == 4))
                {
                    byte cX;
                    if (IsWhite)
                    {
                        cX = 0;
                    }
                    else
                    {
                        cX =7;
                    }

                    if ((_Next.Y == 2) && _Game.Chessboard[cX, 0].GetType().ToString().Contains("Castle") && !(_Game.Chessboard[cX, 0].didMove) && _Game.Chessboard[cX, 1].GetType().ToString().Contains("Empty") && _Game.Chessboard[cX, 2].GetType().ToString().Contains("Empty") && _Game.Chessboard[cX, 2].GetType().ToString().Contains("Empty") && Rookcheck.ChecktestforRook(_Game, _Current, cX, 2) && Rookcheck.ChecktestforRook(_Game, _Current, cX, 3))
                    {
                        return true;
                    }

                }
            }
            return false; 
        }
        
       
        public King(string color)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = 0;
            Current.Y = 0;
            didMove = false;
            didMoveHelper = 0; 

        }

        public King(string color,byte X , byte Y)
        {
            if (color == "BLACK")
            {
                IsWhite = false;
            }
            else IsWhite = true;
            Current.X = X;
            Current.Y = Y;
            didMove = false;
            didMoveHelper = 0; 

        }

    }
}
