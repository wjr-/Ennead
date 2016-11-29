using Ennead.Interfaces;

namespace Ennead.Cards
{
    public class Nine : BaseCard
    {
        public Nine(IPlayer owner)
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
            game.State.SwapNextTwoUnscoredCards();
        }
    }
}
