using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
   
    public class Coordinate
    {
        public byte X { get; set; }
        public byte Y { get; set; }

        public Coordinate()
        {
            X = 0;
            Y = 0;
        }
       
        public Coordinate(byte _X , byte _Y)
        {
            this.X = _X;
            this.Y = _Y; 
        }

    }
    public abstract class CommonProperties
    {
        public bool IsWhite { get; set; }
        public bool didMove { get; set; }
        public byte didMoveHelper { get; set; }
        public Coordinate Current = new Coordinate();
        public static bool whoseturn = true ;
        public byte piecenum;
        public static bool drawHelper; 
        public static bool reverserhelper;
        public static Coordinate reversercoord = new Coordinate(); 
        public static byte reversedPiece;
        public static bool isEmpty;
        public byte enPassantchecker { get; set; }
        public static byte enPassantfinder { get; set; }
        public static bool didEnpassantmove { get; set; }
        public void Move(GameBoard _Game, Coordinate _Current ,Coordinate _Next, Empty _Emptyspace)
        {
            if (!(whoseturn ^ _Game.Chessboard[Current.X, Current.Y].IsWhite))
            {
                whoseturn = !whoseturn;
                _Game.Chessboard[_Current.X, _Current.Y].didMove = true;
                _Game.Chessboard[_Current.X, _Current.Y].didMoveHelper++;
                if (_Game.Chessboard[_Next.X, _Next.Y].GetType().ToString().Contains("Empty"))
                {
                    isEmpty = true;
                }
                else if (!(_Game.Chessboard[_Next.X,_Next.Y].IsWhite))
                {
                    isEmpty = false;
                    

                    for (byte i = 0; i < _Game.Black.Count; i++)
                    {
                        if (_Game.Chessboard[_Next.X, _Next.Y] == _Game.Black[i])
                        {
                            reversedPiece = i;
                          break; 
                        }
                    }
                    reverserhelper = true;
                    reversercoord.X = _Game.Chessboard[_Next.X, _Next.Y].Current.X;
                    reversercoord.Y = _Game.Chessboard[_Next.X, _Next.Y].Current.Y;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = 99;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = 99;
                }
                else
                {
                    isEmpty = false;
                    
                    for (byte i = 0; i < _Game.White.Count; i++)
                    {
                        if (_Game.Chessboard[_Next.X, _Next.Y] == _Game.White[i])
                        {
                           
                            reversedPiece = i;
                            break; 
                        }
                    }
                    reverserhelper = true;
                    reversercoord.X = _Game.Chessboard[_Next.X, _Next.Y].Current.X;
                    reversercoord.Y = _Game.Chessboard[_Next.X, _Next.Y].Current.Y;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = 99;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = 99;
                }

                _Game.Chessboard[_Next.X, _Next.Y] = _Game.Chessboard[_Current.X, _Current.Y];
                _Game.Chessboard[Current.X, Current.Y] = _Emptyspace;
                _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
                _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
                drawHelper = true; 

                if (CommonProperties.didEnpassantmove)
                {
                    if (_Game.Chessboard[_Next.X, _Next.Y].IsWhite)
                    {
                        _Game.Chessboard[_Next.X - 1, _Next.Y] = _Emptyspace; 
                    }
                    else
                    {
                        _Game.Chessboard[_Next.X + 1, _Next.Y] = _Emptyspace; 
                    }
                }
            }
        }
        
        public void Rookmover1(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            _Game.Chessboard[_Next.X, _Next.Y] = _Game.Chessboard[_Current.X, _Current.Y];
            _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
            _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y; 

            _Game.Chessboard[_Current.X, _Current.Y] = _Emptyspace;
            _Game.Chessboard[_Current.X, 5] = _Game.Chessboard[_Current.X, 7];
            _Game.Chessboard[_Current.X, 5].Current.Y = 5; 
            _Game.Chessboard[_Current.X, 7] = _Emptyspace;
            _Game.Chessboard[_Current.X, 5].didMove = true;
            _Game.Chessboard[_Next.X, _Next.Y].didMove = true;
            if (_Game.Chessboard[Current.X, Current.Y].IsWhite)
            {
                whoseturn = false;
            }
            else whoseturn = true;
        }
        
        public void Rookmover2(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            _Game.Chessboard[_Next.X, _Next.Y] = _Game.Chessboard[_Current.X, _Current.Y];
            _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
            _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y; 
            _Game.Chessboard[_Current.X, _Current.Y] = _Emptyspace;
            _Game.Chessboard[_Current.X, 3] = _Game.Chessboard[_Current.X, 0];
            _Game.Chessboard[_Current.X, 3].Current.Y = 3; 
            _Game.Chessboard[_Current.X, 0] = _Emptyspace;
            _Game.Chessboard[_Current.X, 3].didMove = true;
            _Game.Chessboard[_Next.X, _Next.Y].didMove = true;
            if (_Game.Chessboard[Current.X, Current.Y].IsWhite)
            {
                whoseturn = false;
            }
            else whoseturn = true;
        }

    }
}
    