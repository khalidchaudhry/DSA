using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //! Requirement collection 
            /*
                 How many players supportet? two 
                 The size of the board : ?
                 Do we want specific player to start the game 
                 Do we need to ask for user their name?             
                 Allow  users to make move on behave of both the players              
             */
            //! Entitiies/ Identify actors and objects 
            /*
               Application Runner 
               InputProcessor  
               Player  
               Piece
               Board                                             
            */
            //! Detailed Design 
            /*
                  Flow
                      Player  will move Piece 
                      Check if we player have won
                      Repeat for other player
                      
                 Player 
                      Name:string                      
                 Piece
                      Name:string
                      Player: Player
                      PiecePositions: [(int r,inc)]
                Board
                  Properties: 
                     Size:int
                  Methods:
                     Print():void
                     Init():void   
                     Place(): void
              */



        }
    }
}
