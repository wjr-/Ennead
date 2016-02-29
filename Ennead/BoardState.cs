using Ennead.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ennead
{
    public class BoardState
    {
        public List<CardSlot> Queue { get; private set; }
        public List<ICard> PreviouslyPlayed { get; private set; }

        public int[] ValidSlots
        {
            get
            {
                return Enumerable.Range(1, Queue.Count + 1).ToArray();
            }
        }

        public List<CardSlot> UnscoredQueue
        {
            get
            {
                return Queue.Where(c => !c.Scored).ToList();
            }
        }

        public BoardState()
        {
            Queue = new List<CardSlot>();
            PreviouslyPlayed = new List<ICard>();
        }

        public int CostToPlay(int position)
        {
            return Queue.Count - (position - 1);
        }

        public void Play(Player player, ICard card, int position)
        {
            Queue.Insert(position - 1, new CardSlot() { Card = card, Owner = player });
        }
    }
}
