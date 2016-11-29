using System.Collections.Generic;

namespace Ennead.Interfaces
{
    public interface IRules
    {
        int NumberOfPlayers { get; }
        int NumberOfRounds { get; }
        int StartingGoldPerPlayer { get; }
        int NumberOfPlayerTurns { get; }
        List<ICard> GetStartingHandOfCards(IPlayer player);
    }
}