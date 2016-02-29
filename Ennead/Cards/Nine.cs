using System.Linq;
using Ennead.Interfaces;

namespace Ennead.Cards
{
    public class Nine : BaseCard
    {
        public Nine(Player owner)
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
            if(NextCards(game).Count < 2)
            {
                return;
            }

            var temp = NextCards(game)[0];
            NextCards(game)[0] = NextCards(game)[1];
            NextCards(game)[1] = temp;
        }
    }
}
