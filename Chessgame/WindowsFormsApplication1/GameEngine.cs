using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class GameEngine
    {
        public Coordinate promotionCoord = new Coordinate();
        public bool anyChanges; 
        public void Run(GameBoard Game,Coordinate Current ,Coordinate Next,Check Checker, Empty Emptyspace)
        {
            string typecheck;
            typecheck = Game.Chessboard[Current.X, Current.Y].GetType().ToString();

            switch (typecheck)
            {
                case "Chess.Pawn":
                    Pawn Pawnmover = new Pawn("WHITE");
                    Pawnmover = (Pawn)Game.Chessboard[Current.X, Current.Y];
                    if (Pawnmover.isMovable(Game, Next))
                    {
                       
                        Game.Chessboard[Current.X, Current.Y].Move(Game, Current, Next, Emptyspace);
                        if (!(Checker.Checktest(Game, Next)))
                        {
                            Game.LastmoveReverser(Game, Current, Next, Emptyspace);
                            
                        }
                        else
                        {
                            anyChanges = true;
                        }
                        
                        
                    }

                    break;

                case "Chess.Bishop":

                    Bishop Bishopmover = new Bishop("a");
                    Bishopmover = (Bishop)Game.Chessboard[Current.X, Current.Y];
                    if (Bishopmover.isMovable(Game, Next))
                    {
                       
                        Game.Chessboard[Current.X, Current.Y].Move(Game, Current, Next, Emptyspace);
                        if (!(Checker.Checktest(Game, Next)))
                        {
                            Game.LastmoveReverser(Game, Current, Next, Emptyspace);
                        }
                        else
                        {
                            anyChanges = true;
                        }
                    }
                    break;

                case "Chess.Queen":

                    Queen Queenmover = new Queen("a");
                    Queenmover = (Queen)Game.Chessboard[Current.X, Current.Y];
                    if (Queenmover.isMovable(Game, Next))
                    {
                       
                        Game.Chessboard[Current.X, Current.Y].Move(Game, Current, Next, Emptyspace);
                        if (!(Checker.Checktest(Game, Next)))
                        {
                            Game.LastmoveReverser(Game, Current, Next, Emptyspace);
                        }
                        else
                        {
                            anyChanges = true;
                        }
                    }
                    break;

                case "Chess.Knight":

                    Knight Knightmover = new Knight("a");
                    Knightmover = (Knight)Game.Chessboard[Current.X, Current.Y];
                    if (Knightmover.isMovable(Game, Next))
                    {
                       
                        Game.Chessboard[Current.X, Current.Y].Move(Game, Current, Next, Emptyspace);
                        if (!(Checker.Checktest(Game, Next)))
                        {
                            Game.LastmoveReverser(Game, Current, Next, Emptyspace);
                        }
                        else
                        {
                            anyChanges = true;
                        }
                    }
                    break;

                case "Chess.Castle":

                    Castle Castlemover = new Castle("a");
                    Castlemover = (Castle)Game.Chessboard[Current.X, Current.Y];
                    if (Castlemover.isMovable(Game, Next))
                    {
                         Game.Chessboard[Current.X, Current.Y].Move(Game, Current, Next, Emptyspace);
                        if(!(Checker.Checktest(Game, Next)))
                        {
                            Game.LastmoveReverser(Game, Current, Next, Emptyspace); 
                        }
                        else
                        {
                            anyChanges = true;
                        }
                       
                    }
                    break;

                case "Chess.King":

                    King Kingmover = new King("a");
                    Kingmover = (King)Game.Chessboard[Current.X, Current.Y];
                    if (Kingmover.isMovable(Game, Next))
                    {
                        
                        Game.Chessboard[Current.X, Current.Y].Move(Game, Current, Next, Emptyspace);
                        if (!(Checker.Checktest(Game, Next)) )
                        {
                            Game.LastmoveReverser(Game, Current, Next, Emptyspace);
                        }
                        else
                        {
                            anyChanges = true;
                        }

                    }

                    else if (Kingmover.Rooktest1(Game, Current, Next, Emptyspace) && Checker.Checktest(Game, Current))
                    {
                      
                        Game.Chessboard[Current.X, Current.Y].Rookmover1(Game, Current, Next, Emptyspace);
                        anyChanges = true; 

                    }

                    else if (Kingmover.Rooktest2(Game, Current, Next, Emptyspace) && Checker.Checktest(Game, Current))
                    {
                      
                        Game.Chessboard[Current.X, Current.Y].Rookmover2(Game, Current, Next, Emptyspace);
                        anyChanges = true; 

                    }

                    break;
            }
            if(CommonProperties.enPassantfinder +1 > Game.White.Count || CommonProperties.enPassantfinder +1 > Game.Black.Count)
            {
                CommonProperties.enPassantfinder = 0; 
            }
            if(Game.White[CommonProperties.enPassantfinder].enPassantchecker == 2)
            {
                Game.White[CommonProperties.enPassantfinder].enPassantchecker -= 1; 
            }
            else if (Game.White[CommonProperties.enPassantfinder].enPassantchecker == 1)
            {
                Game.White[CommonProperties.enPassantfinder].enPassantchecker -= 1;
            }
            if (Game.Black[CommonProperties.enPassantfinder].enPassantchecker == 2)
            {
                Game.Black[CommonProperties.enPassantfinder].enPassantchecker -= 1;
            }
            else if (Game.Black[CommonProperties.enPassantfinder].enPassantchecker == 1)
            {
                Game.Black[CommonProperties.enPassantfinder].enPassantchecker -= 1;
            }
            
        }
        public bool Promotionchecker(GameBoard _Game)
        {   
           if(CommonProperties.whoseturn)
           {
               for(int i = 0 ; i<8 ; i++)
               {
                   if (_Game.Chessboard[0, i].GetType().ToString().Contains("Pawn"))
                   {
                       promotionCoord.X = 0;
                       promotionCoord.Y = (byte) i;
                       anyChanges = true; 
                       return true;
                   } 
               }
           }
           else
           {
               for (int i = 0; i < 8; i++)
               {
                   if (_Game.Chessboard[7, i].GetType().ToString().Contains("Pawn"))
                   {
                       promotionCoord.X = 7;
                       promotionCoord.Y = (byte) i;
                       anyChanges = true; 
                       return true;
                   }
               }
           }
           return false; 
        }
       

    }
}
