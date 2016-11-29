using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class Five : BaseCard
    {
        public Five(IPlayer owner)
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
            foreach (var player in game.Players.Except(new[] { Owner }))
            {
                player.Gold -= 1;
            }
        }
    }
}