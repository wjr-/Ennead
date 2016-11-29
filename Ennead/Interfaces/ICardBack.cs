using Ennead.Cards;

namespace Ennead.Interfaces
{
    public interface ICardBack
    {
        CardCategory Category { get; }
        IPlayer Owner { get; }
    }
}
