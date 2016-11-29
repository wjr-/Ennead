using System;
using Ennead.Cards;
using Ennead.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Ennead
{
    public abstract class BaseCard : ICard
    {
        public IPlayer Owner { get; private set; }

        public abstract CardCategory Category { get; }
        public abstract void Resolve(Game game);

        public BaseCard(IPlayer owner)
        {
            Owner = owner;
        }

        public override string ToString()
        {
            switch (Category)
            {
                case CardCategory.First:
                    return "[+]";
                case CardCategory.Second:
                    return "[-]";
                case CardCategory.Third:
                    return "[<]";
                default:
                    return "wtf";
            }
        }

        protected IReadOnlyCollection<BoardState.CardSlot> NextCards(Game game)
        {
            return game.State.UnscoredQueue.Skip(1).ToList().AsReadOnly();
        }

        protected BoardState.CardSlot NextCard(Game game)
        {
            return game.State.UnscoredQueue.FirstOrDefault();
        }
    }
}
