using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions ;

namespace Chess
{
    public class GameBoard
    {

        public   CommonProperties[,] Chessboard = new CommonProperties[8, 8]; 
        public List<CommonProperties> Black = new List<CommonProperties>() ; 
        public List<CommonProperties> White = new List<CommonProperties>() ;
    
        public GameBoard()
        {
            King BlackKing = new King("BLACK");
            Queen BlackQueen = new Queen("BLACK",1);
            Castle BlackCastle1 = new Castle("BLACK",1);
            Castle BlackCastle2 = new Castle("BLACK",2);
            Bishop BlackBishop1 = new Bishop("BLACK",1);
            Bishop BlackBishop2 = new Bishop("BLACK",2);
            Knight BlackKnight1 = new Knight("BLACK",1);
            Knight BlackKnight2 = new Knight("BLACK",2);
            Pawn BlackPawn1 = new Pawn("BLACK",1);
            Pawn BlackPawn2 = new Pawn("BLACK",2);
            Pawn BlackPawn3 = new Pawn("BLACK",3);
            Pawn BlackPawn4 = new Pawn("BLACK",4);
            Pawn BlackPawn5 = new Pawn("BLACK",5);
            Pawn BlackPawn6 = new Pawn("BLACK",6);
            Pawn BlackPawn7 = new Pawn("BLACK",7);
            Pawn BlackPawn8 = new Pawn("BLACK",8);
            Empty Emptyspace = new Empty();
            for (byte i = 2; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    Chessboard[i, j] = Emptyspace; 
                }
            }

            Black.Add(BlackKing);
            Black.Add(BlackQueen);
            Black.Add(BlackCastle1);
            Black.Add(BlackCastle2);
            Black.Add(BlackBishop1);
            Black.Add(BlackBishop2);
            Black.Add(BlackKnight1);
            Black.Add(BlackKnight2);
            Black.Add(BlackPawn1);
            Black.Add(BlackPawn2);
            Black.Add(BlackPawn3);
            Black.Add(BlackPawn4);
            Black.Add(BlackPawn5);
            Black.Add(BlackPawn6);
            Black.Add(BlackPawn7);
            Black.Add(BlackPawn8);

            King WhiteKing = new King("WHITE");
            Queen WhiteQueen = new Queen("WHITE",1);
            Castle WhiteCastle1 = new Castle("WHITE",1);
            Castle WhiteCastle2 = new Castle("WHITE",2);
            Bishop WhiteBishop1 = new Bishop("WHITE",1);
            Bishop WhiteBishop2 = new Bishop("WHITE",2);
            Knight WhiteKnight1 = new Knight("WHITE",1);
            Knight WhiteKnight2 = new Knight("WHITE",2);
            Pawn WhitePawn1 = new Pawn("WHITE",1);
            Pawn WhitePawn2 = new Pawn("WHITE",2);
            Pawn WhitePawn3 = new Pawn("WHITE",3);
            Pawn WhitePawn4 = new Pawn("WHITE",4);
            Pawn WhitePawn5 = new Pawn("WHITE",5);
            Pawn WhitePawn6 = new Pawn("WHITE",6);
            Pawn WhitePawn7 = new Pawn("WHITE",7);
            Pawn WhitePawn8 = new Pawn("WHITE",8);
            White.Add(WhiteKing);
            White.Add(WhiteQueen);
            White.Add(WhiteCastle1);
            White.Add(WhiteCastle2);
            White.Add(WhiteBishop1);
            White.Add(WhiteBishop2);
            White.Add(WhiteKnight1);
            White.Add(WhiteKnight2);
            White.Add(WhitePawn1);
            White.Add(WhitePawn2);
            White.Add(WhitePawn3);
            White.Add(WhitePawn4);
            White.Add(WhitePawn5);
            White.Add(WhitePawn6);
            White.Add(WhitePawn7);
            White.Add(WhitePawn8);

            Chessboard[0, 0] = WhiteCastle1;
            Chessboard[0, 1] = WhiteKnight1;
            Chessboard[0, 2] = WhiteBishop1;
            Chessboard[0, 3] = WhiteQueen;
            Chessboard[0, 4] = WhiteKing;
            Chessboard[0, 5] = WhiteBishop2; 
            Chessboard[0, 6] = WhiteKnight2;
            Chessboard[0, 7] = WhiteCastle2;

            Chessboard[1, 0] = WhitePawn1;
            Chessboard[1, 1] = WhitePawn2; 
            Chessboard[1, 2] = WhitePawn3; 
            Chessboard[1, 3] = WhitePawn4; 
            Chessboard[1, 4] = WhitePawn5; 
            Chessboard[1, 5] = WhitePawn6; 
            Chessboard[1, 6] = WhitePawn7; 
            Chessboard[1, 7] = WhitePawn8; 

            Chessboard[7, 0] = BlackCastle1;
            Chessboard[7, 1] = BlackKnight1;
            Chessboard[7, 2] = BlackBishop1;
            Chessboard[7, 3] = BlackQueen;
            Chessboard[7, 4] = BlackKing;
            Chessboard[7, 5] = BlackBishop2;
            Chessboard[7, 6] = BlackKnight2;
            Chessboard[7, 7] = BlackCastle2;
            
            Chessboard[6, 0] = BlackPawn1;
            Chessboard[6, 1] = BlackPawn2;
            Chessboard[6, 2] = BlackPawn3;
            Chessboard[6, 3] = BlackPawn4;
            Chessboard[6, 4] = BlackPawn5;
            Chessboard[6, 5] = BlackPawn6;
            Chessboard[6, 6] = BlackPawn7;
            Chessboard[6, 7] = BlackPawn8;

            for (byte i = 0 ; i<8 ; i++)
            {
                for(byte j= 0 ; j<8 ; j++)
                {
                    if(!(Chessboard[i,j].GetType().ToString().Contains("Empty")))
                    {
                        Chessboard[i, j].Current.X = i;
                        Chessboard[i, j].Current.Y = j; 
                    }
                }
            }

        }
       
        public void PieceRemover(GameBoard _Game,Coordinate _Next,Empty Emptyspace)
        {
            if(!(_Game.Chessboard[_Next.X,_Next.Y].GetType().ToString().Contains("Empty")))
            {
                if(_Game.Chessboard[_Next.X, _Next.Y].IsWhite)
                {
                    for(int i = 0 ; i< _Game.White.Count ; i++)
                    {
                        if (_Game.White[i] == _Game.Chessboard[_Next.X, _Next.Y])
                        {
                            _Game.White.Remove(_Game.White[i]);
                        }
                       
                    }
                }
                else
                {
                    for (int i = 0; i < _Game.Black.Count; i++)
                    {
                        if (_Game.Black[i] == _Game.Chessboard[_Next.X, _Next.Y])
                        {
                            _Game.Black.Remove(_Game.Black[i]);
                        }

                    }
                }
               
            }
        }
        public void LastmoveReverser(GameBoard _Game, Coordinate _Current, Coordinate _Next, Empty _Emptyspace)
        {
            if (_Game.Chessboard[_Next.X, _Next.Y].didMoveHelper == 1)
            {
                _Game.Chessboard[_Next.X, _Next.Y].didMove = false;
                _Game.Chessboard[_Next.X, _Next.Y].didMoveHelper--;
            }
            _Game.Chessboard[_Current.X, _Current.Y] = _Game.Chessboard[_Next.X, _Next.Y];
            _Game.Chessboard[_Current.X, _Current.Y].Current.X = _Current.X;
            _Game.Chessboard[_Current.X, _Current.Y].Current.Y = _Current.Y;
            CommonProperties.whoseturn = !CommonProperties.whoseturn;
            if ((CommonProperties.isEmpty))
            {
                _Game.Chessboard[_Next.X, _Next.Y] = _Emptyspace;
                CommonProperties.isEmpty = false;
            }
            else
            {
                if (CommonProperties.whoseturn)
                {
                    _Game.Chessboard[_Next.X, _Next.Y] = _Game.Black[CommonProperties.reversedPiece];
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
                }
                else
                {
                    _Game.Chessboard[_Next.X, _Next.Y] = _Game.White[CommonProperties.reversedPiece];
                    _Game.Chessboard[_Next.X, _Next.Y].Current.X = _Next.X;
                    _Game.Chessboard[_Next.X, _Next.Y].Current.Y = _Next.Y;
                }
            }
            CommonProperties.reverserhelper = false; 

        }
    }
   
    public class Empty : CommonProperties
    {

    }
}
