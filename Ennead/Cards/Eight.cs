using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class Eight : BaseCard
    {
        public Eight(IPlayer owner)
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
                NextCard(game).SetOwner(Owner);
            }
        }
    }
}