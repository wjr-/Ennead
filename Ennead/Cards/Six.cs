using System;
using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class Six : BaseCard
    {
        public Six(Player owner)
            : base(owner)
        {

        }

        public override CardCategory Category
        {
            get
            {
                return CardCategory.Second;
            }
        }
        public override void Resolve(Game game)
        {
            if (NextCards(game).Any())
            {
                NextCard(game).Owner.Gold -= 2;
            }
        }
    }
}
