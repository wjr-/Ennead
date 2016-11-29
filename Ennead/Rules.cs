using System.Collections.Generic;
using Ennead.Interfaces;
using Ennead.Cards;

namespace Ennead
{
    public class Rules : IRules
    {
        public int NumberOfPlayers
        {
            get
            {
                return 4;
            }
        }

        public int StartingGoldPerPlayer
        {
            get
            {
                return 5;
            }
        }

        public int NumberOfRounds
        {
            get
            {
                return NumberOfPlayers;
            }
        }

        public int NumberOfPlayerTurns
        {
            get
            {
                return 3;
            }
        }

        public List<ICard> GetStartingHandOfCards(IPlayer player)
        {
            return new List<ICard>()
            {
                new One(player), new Two(player), new Three(player), new Four(player), new Five(player), new Six(player), new Seven(player), new Eight(player), new Nine(player)
            };
        }
    }
}
