using System.Collections.Generic;

namespace Ennead.Interfaces
{
    public interface IPlayer
    {
        int Gold { get; set; }
        IReadOnlyCollection<ICardBack> HandOfCards { get; }
        string Name { get; }

        void Play(BoardState boardState);
        void GiveCards(params ICard[] cards);

        bool HasGoldToPlay(int position, BoardState boardState);
        ICard ChooseCard();
    }
}