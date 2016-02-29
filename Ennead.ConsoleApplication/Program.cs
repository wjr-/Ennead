namespace Ennead.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new Rules());

            game.Play();
        }
    }
}
