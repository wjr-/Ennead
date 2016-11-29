using Ennead.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ennead
{
    public delegate void BoardStateChangedHandler(object sender, EventArgs args);

    public class BoardState
    {
        private List<CardSlot> queue;
      
        public List<ICard> PreviouslyPlayed { get; private set; }

        public event BoardStateChangedHandler Changed;

        public int[] ValidSlots
        {
            get
            {
                return Enumerable.Range(1, queue.Count + 1).ToArray();
            }
        }

        public IReadOnlyCollection<CardSlot> UnscoredQueue
        {
            get
            {
                return queue.Where(c => !c.Scored)
                    .ToList()
                    .AsReadOnly();
            }
        }

        public IReadOnlyCollection<CardSlot> ScoredQueue
        {
            get
            {
                return queue.Where(c => c.Scored)
                    .ToList()
                    .AsReadOnly();
            }
        }

        public BoardState()
        {
            queue = new List<CardSlot>();
            PreviouslyPlayed = new List<ICard>();
        }

        public int CostToPlay(int position)
        {
            return queue.Count - (position - 1);
        }

        public void Play(ICard card, int position)
        {
            queue.Insert(position - 1, new CardSlot(card));
            OnChange();
        }

        public void ClearQueueToPreviouslyPlayed()
        {            
            PreviouslyPlayed.AddRange(queue.Select(s => s.Card));
            queue.Clear();
            OnChange();
        }

        public void SwapNextTwoUnscoredCards()
        {
            if(UnscoredQueue.Count >= 3)
            {
                queue = ScoredQueue
                    .Concat(new [] { UnscoredQueue.First() }) // current
                    .Concat(new [] { UnscoredQueue.Skip(2).First(), UnscoredQueue.Skip(1).First() }) // next two
                    .Concat(UnscoredQueue.Skip(3)) // the rest
                    .ToList();
            }
            OnChange();
        }

        public override string ToString()
        {
            var strings = queue.Select(s => s.ToString());
            
            return strings.Any() 
                ? strings.Aggregate((s, acc) => acc += s)
                : String.Empty;
        }

        private void OnChange()
        {
            if (Changed != null)
            {
                Changed(this, new EventArgs());
            }
        }

        public class CardSlot
        {
            private ICard card;

            public IPlayer Owner { get; private set; }
            public bool Scored { get; private set; }

            public bool Skip { get; set; }    
            
            public ICard Card
            {
                get
                {
                    if (Scored)
                    {
                        return card;
                    }
                    throw new Exception("Don't peek unscored cards!");
                }
            }

            public CardSlot(ICard card)
            {
                this.card = card;
                Owner = card.Owner;
            }

            public void Resolve(Game game)
            {
                if (!Skip)
                {
                    card.Resolve(game);
                }

                Scored = true;
            }

            public void SetOwner(IPlayer newOwner)
            {
                Owner = newOwner;
            }

            public override string ToString()
            {
                return card + ((Scored) ? " scored" : "");
            }
        }
    }
}
