using System.Linq;
using Ennead.Interfaces;
using System.Collections.Generic;

namespace Ennead.Cards
{
    public class One : BaseCard
    {
        public One(Player owner)
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
