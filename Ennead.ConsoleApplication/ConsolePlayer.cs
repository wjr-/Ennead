using Ennead.Interfaces;


namespace Ennead.ConsoleApplication
{
    class ConsolePlayer : Player
    {
        public ConsolePlayer(int number, string name, IRules rules)
            : base(name, rules)
        {
            Number = number;
        }

        public int Number { get; private set; }
    }
}
