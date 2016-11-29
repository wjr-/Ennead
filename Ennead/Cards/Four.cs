using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class Four : BaseCard
    {
        public Four(IPlayer owner)
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
            if (NextCards(game).Any() && NextCard(game).Owner.Gold > 0)
            {
                NextCard(game).Owner.Gold -= 1;
                Owner.Gold += 1;
            }
        }
    }
}
