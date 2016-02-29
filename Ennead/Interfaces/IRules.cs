using System.Collections.Generic;
using Ennead.Interfaces;

namespace Ennead.Interfaces
{
    public interface IRules
    {
        int NumberOfPlayers { get; }
        int NumberOfRounds { get; }
        int StartingGoldPerPlayer { get; }
        List<ICard> GetStartingHandOfCards(Player player);
    }
}