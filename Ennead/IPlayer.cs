using System.Collections.Generic;
using Ennead.Cards;
using Ennead.Interfaces;

namespace Ennead
{
    public interface IPlayer
    {
        int Gold { get; set; }
        IList<ICard> HandOfCards { get; }
        string Name { get; }
        int Number { get; }

        bool HasGoldToPlay(int position);
        void Play();
        IList<ICard> SelectTwoCards(params CardCategory[] categories);
    }
}