using Ennead.Interfaces;

namespace Ennead
{
    public class CardSlot
    {
        public ICard Card { get; set; }
        public IPlayer Owner { get; set; }
        public bool Skip { get; set; }
        public bool Scored { get; set; }
        public bool FaceUp { get; set; }

        public CardSlot()
        {
        }

        public void Resolve(Game game)
        {
            FaceUp = true;

            if (!Skip)
            {
                Card.Resolve(game);
            }

            Scored = true;
        }

        public override string ToString()
        {
            return Card + ((Scored) ? " scored" : "");
        }
    }
}
