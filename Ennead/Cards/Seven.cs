using System;
using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class Seven : BaseCard
    {
        public Seven(Player owner)
            : base(owner)
        {

        }

        public override CardCategory Category
        {
            get
            {
                return CardCategory.Third;
            }
        }

        public override void Resolve(Game game)
        {
            if (NextCards(game).Any())
            {
                NextCard(game).Skip = true;
            }
        }
    }
}