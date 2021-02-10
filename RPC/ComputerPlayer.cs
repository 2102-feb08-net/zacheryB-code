using System;
using System.Text;
using System.Collections.Generic;

namespace RPC
{
    public class ComputerPlayer : Player
    {
        //Random number generator
        private Random random = new Random();

        //Holds the history of the player's plays
        private List<RPCEnum> previousPlays = new List<RPCEnum>();

        public List<RPCEnum> PreviousPlays
        {
            get { return previousPlays; }
        }

        //Makes the play for the computer
        public override RPCEnum makePlay()
        {
            int choice = random.Next(1, 4);
            RPCEnum[] values = (RPCEnum[])Enum.GetValues(typeof(RPCEnum));
            switch(choice)
            {
                case 1:
                {   
                    previousPlays.Add(values[0]);
                    return values[0];
                }
                case 2:
                {   
                    previousPlays.Add(values[1]);
                    return values[1];
                }
                case 3:
                {   
                    previousPlays.Add(values[2]);
                    return values[2];
                }
                default:
                    throw new NotImplementedException("Invalid choice when picking, thrown in ComputerPlayer.cs");
            }
        }
    }
}