using System.Linq;

namespace Ennead.Cards
{
    public class Three : BaseCard
    {
        public Three(Player owner)
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
            if (NextCards(game).Any())
            {
                NextCard(game).Owner.Gold += 3;
            }
        }
    }
}
