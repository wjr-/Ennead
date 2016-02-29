using Ennead.Interfaces;
using System.Collections.Generic;
using System;
using Ennead.Cards;
using System.Linq;

namespace Ennead
{
    public class Player
    {
        private BoardState gameState;

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

        public string Name
        {
            get
            {
                return $"Player {Number}";
            }
        }

        public List<ICard> HandOfCards { get; private set; }
        public int Number { get; private set;}
        
        public Player(int number, IRules rules, BoardState gameState)
        {
            this.gameState = gameState;

            Number = number;

            HandOfCards = rules.GetStartingHandOfCards(this);
            Gold = rules.StartingGoldPerPlayer;
        }

        public IList<ICard> SelectTwoCards(params CardCategory[] categories)
        {
            List<ICard> chosen;

            if (categories.Length == 0)
            {
                // randomize
                chosen = new List<ICard>() { HandOfCards[1], HandOfCards[7] };              
            }
            else
            {
                chosen = new List<ICard>() { HandOfCards.First(c => c.Category == categories[0]), HandOfCards.First(c => c.Category == categories[1]) };
            }

            HandOfCards.Remove(chosen[0]);
            HandOfCards.Remove(chosen[1]);

            return chosen;
        }

        public bool HasGoldToPlay(int position)
        {
            return Gold >= gameState.CostToPlay(position);
        }
        
        public void Play()
        {
            ICard card = ChooseCard();
            int slot = ChooseSlot(card);

            Play(card, slot);
        }

        public override string ToString()
        {
            return $"Player {Number}, cards: {HandOfCards.Count}, gold: {Gold}";
        }

        private ICard ChooseCard()
        {
            var rand = new Random();

            return HandOfCards[rand.Next(0, HandOfCards.Count - 1)];
        }

        private int ChooseSlot(ICard card)
        {
            var rand = new Random();

            while(true)
            {
                int slot = gameState.ValidSlots[rand.Next(0, gameState.ValidSlots.Length)];
                if(HasGoldToPlay(slot))
                {
                    return slot;
                }
            }
        }

        private void Play(ICard card, int position)
        {
            if (!HasGoldToPlay(position))
            {
                throw new Exception("Not enough gold.");
            }

            gameState.Play(this, card, position);

            Gold -= gameState.CostToPlay(position);
            HandOfCards.Remove(card);
        }
    }
}
