using Ennead.Interfaces;
using System.Linq;

namespace Ennead
{
    public class Player : PlayerBase
    {
        public Player(string name, IRules rules)
            : base(name, rules)
        {
        }
        
        public override ICard ChooseCard()
        {
            ICard chosen = Randomizer.Instance.Choose(handOfCards);
            handOfCards.Remove(chosen);
            return chosen;
        }

        protected override int ChooseSlot(ICard card, BoardState boardState)
        {
            return Randomizer.Instance.Choose(boardState.ValidSlots.Where(s => HasGoldToPlay(s, boardState)).ToList());
        }
    }
}
