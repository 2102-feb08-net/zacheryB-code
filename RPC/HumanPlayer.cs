using System;
using System.Collections.Generic;

namespace RPC
{
    public class HumanPlayer : Player
    {
        //Holds the history of the player's plays
        private List<RPCEnum> previousPlays = new List<RPCEnum>();
        public List<RPCEnum> PreviousPlays
        {
            get { return previousPlays; }
        }

        public override RPCEnum makePlay()
        {
            string choice = "";
            Console.WriteLine("Please type out your choice: 'Rock' 'Paper' 'Scissors'");
            do
            {
                choice = Console.ReadLine();
                switch(choice.ToLower())
                {
                    case "rock":
                    {
                        previousPlays.Add(RPCEnum.Rock);
                        return RPCEnum.Rock;
                    }
                    case "paper":
                    {
                        previousPlays.Add(RPCEnum.Paper);
                        return RPCEnum.Paper;
                    }
                    case "scissors":
                    {
                        previousPlays.Add(RPCEnum.Scissors);
                        return RPCEnum.Scissors;
                    }
                    default:
                        choice = "";
                        break;
                }
            }while(choice == "");
            throw new NotImplementedException("Don't know how I got here");
        }
    }
}