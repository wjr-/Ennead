using Ennead.Interfaces;
using System.Linq;

namespace Ennead.Cards
{
    public class One : BaseCard
    {
        public One(IPlayer owner)
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
            Owner.Gold += 3;

            foreach(Player player in game.Players.Except(new [] { Owner }))
            {
                player.Gold += 1;
            }
        }
    }
}
