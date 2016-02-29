using Ennead.Cards;

namespace Ennead.Interfaces
{
    public interface ICard
    {
        CardCategory Category { get;}
        void Resolve(Game game);
    }
}