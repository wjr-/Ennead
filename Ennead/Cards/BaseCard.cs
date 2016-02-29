using System;
using Ennead.Cards;
using Ennead.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Ennead
{
    public abstract class BaseCard : ICard
    {
        public Player Owner { get; private set; }

        public abstract CardCategory Category { get; }
        public abstract void Resolve(Game game);

        public BaseCard(Player owner)
        {
            Owner = owner;
        }

        public override string ToString()
        {
            return GetType().Name +  $"-{Category}-{Owner.Name}";
        }

        protected CardSlot NextCard(Game game)
        {
            return game.State.UnscoredQueue.Skip(1).FirstOrDefault();
        }

        protected List<CardSlot> NextCards(Game game)
        {
            return game.State.UnscoredQueue.Skip(1).ToList();
        }
    }
}
