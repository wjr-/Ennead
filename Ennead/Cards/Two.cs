using System;
using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class Two : BaseCard
    {
        public Two(Player owner)
            : base(owner)
        {

        }

        public override CardCategory Category
        {
            get
            {
                return CardCategory.First;
            }
        }

        public override void Resolve(Game game)
        {
            Owner.Gold += NextCards(game).Count;
        }
    }
}
