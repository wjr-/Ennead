using Ennead.Interfaces;

namespace Ennead.Cards
{
    public class Two : BaseCard
    {
        public Two(IPlayer owner)
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
