using System;
using System.Text;
using System.Collections.Generic;

namespace RPC
{
    class Program
    {
        //Must be an odd number!!!
        private static double maxNumberOfGames = 5;
        private static int currentPlayerWins = 0;
        private static int currentComputerWins = 0;

        ///Method: Main()
        ///Param1: args - Command line arguments
        ///Return Type: void
        ///Purpose: Controls the flow of program
        static void Main(string[] args)
        {
            if(maxNumberOfGames % 2 == 0)
                throw new Exception("No valid value in the maxNumberOfGames variable");
            int numberOfGamesNeededToWin = (int)Math.Ceiling((double)(maxNumberOfGames/2));

            ComputerPlayer CP = new ComputerPlayer();
            HumanPlayer HP = new HumanPlayer();

            WelcomeMessage();

            ///Loops until a winner is determined
            while(currentComputerWins < numberOfGamesNeededToWin && currentPlayerWins < numberOfGamesNeededToWin)
            {
                RPCEnum computerPlay = CP.makePlay();
                RPCEnum humanPlay = HP.makePlay();

                EvaluateWinnerOfRound(computerPlay, humanPlay);
            }

            ///Displays the winner message
            if(currentComputerWins == numberOfGamesNeededToWin)
                Console.WriteLine("Congratulations Computer, YOU WIN!");
            else
                Console.WriteLine("Congratulations human, YOU WIN!");

            Console.WriteLine(DisplayHistory(CP.PreviousPlays, HP.PreviousPlays));
        }

        ///Method: EvaluateWinnerOfRound()
        ///Param1: CP - The result of the computer play (Rock, Paper, or Scissors)
        ///Param2: HP - The result of the human play (Rock, Paper, or Scissors)
        ///Return Type: void
        ///Purpose: Evaluates the winner of the round
        static void EvaluateWinnerOfRound(RPCEnum CP, RPCEnum HP)
        {
            Console.WriteLine("Computer Plays: " + CP.ToString());
            Console.WriteLine("Human Plays: " + HP.ToString());

            if(CP == RPCEnum.Rock)
            {
                switch(HP)
                {
                    case RPCEnum.Rock:
                        Tie();
                        break;
                    case RPCEnum.Paper:
                        HumanWin();
                        break;
                    case RPCEnum.Scissors:
                        ComputerWin();
                        break;
                }
            }
            if(CP == RPCEnum.Paper)
            {
                switch(HP)
                {
                    case RPCEnum.Rock:
                        ComputerWin();
                        break;
                    case RPCEnum.Paper:
                        Tie();
                        break;
                    case RPCEnum.Scissors:
                        HumanWin();
                        break;
                }
            }
            if(CP == RPCEnum.Scissors)
            {
                switch(HP)
                {
                    case RPCEnum.Rock:
                        HumanWin();
                        break;
                    case RPCEnum.Paper:
                        ComputerWin();
                        break;
                    case RPCEnum.Scissors:
                        Tie();
                        break;
                }
            }
        }

        ///Method: Tie()
        ///Return Type: void
        ///Purpose: Displays the tie message
        static void Tie()
        {
            Console.WriteLine("It's a tie!\n\n");
        }

        ///Method: HumanWin()
        ///Return Type: void
        ///Purpose: Displays the tie message
        static void HumanWin()
        {
            currentPlayerWins++;
            Console.WriteLine("Human won round!\n\n");
        }

        ///Method: ComputerWin()
        ///Return Type: void
        ///Purpose: Displays the tie message
        static void ComputerWin()
        {
            currentComputerWins++;
            Console.WriteLine("Computer won round!\n\n");
        }

        ///Method: DisplayHistory()
        ///Param1: computerPlays - A list of enums relating to what the computer played
        ///Param2: humanPlays - A list of enums relating to what the human played
        ///Return Type: void
        ///Purpose: Welcome's the human player to the game.
        static string DisplayHistory(List<RPCEnum> computerPlays, List<RPCEnum> humanPlays)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\t\tHuman | Computer");
            for(int i = 0; i < humanPlays.Count; i++)
            {
                sb.AppendLine("\t" + humanPlays[i] + "\t\t|\t" + computerPlays[i]);
            }
            return sb.ToString();
        }

        ///Method: WelcomeMessage()
        ///Params: None
        ///Return Type: void
        ///Purpose: Welcome's the human player to the game.
        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors");
            Console.WriteLine("We will play a maximum of " + maxNumberOfGames + " games");
            Console.WriteLine("So best " + Math.Ceiling((double)(maxNumberOfGames/2)) + "/" + maxNumberOfGames);
            Console.WriteLine("May the best person win!");
        }
    }
}