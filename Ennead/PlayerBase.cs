using Ennead.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ennead
{
    public abstract class PlayerBase : IPlayer
    {
        protected List<ICard> handOfCards;

        private int gold;
        public int Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = (value < 0)
                    ? 0
                    : value;
            }
        }

        public IReadOnlyCollection<ICardBack> HandOfCards
        {
            get
            {
                return handOfCards.Cast<ICardBack>().ToList().AsReadOnly();
            }
        }

        public string Name { get; private set; }
        
        public PlayerBase(string name, IRules rules)
        {
            handOfCards = rules.GetStartingHandOfCards(this);
            Name = name;    
            Gold = rules.StartingGoldPerPlayer;
        }

        public bool HasGoldToPlay(int position, BoardState boardState)
        {
            return Gold >= boardState.CostToPlay(position);
        }

        public void GiveCards(params ICard[] cards)
        {
            handOfCards.AddRange(cards);
        }

        public void Play(BoardState boardState)
        {
            ICard card = ChooseCard();
            int slot = ChooseSlot(card, boardState);

            Play(card, slot, boardState);
        }

        public abstract ICard ChooseCard();

        public override string ToString()
        {
            return $"{Name} ({Gold})";
        }

        protected abstract int ChooseSlot(ICard card, BoardState boardState);

        protected void Play(ICard card, int position, BoardState boardState)
        {
            if (!HasGoldToPlay(position, boardState))
            {
                throw new Exception("Not enough gold.");
            }

            Gold -= boardState.CostToPlay(position);
            handOfCards.Remove(card);

            boardState.Play(card, position);
        }
    }
}
