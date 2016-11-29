using Ennead.Interfaces;
using System;
using System.Linq;

namespace Ennead.ConsoleApplication
{
    class Program
    {
        private static ConsoleColor[] PlayerColors = new[]
        {
            ConsoleColor.Black, // no player 0,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Red,
            ConsoleColor.Yellow
        };

        static void Main(string[] args)
        {
            var rules = new Rules();

            var game = new Game(rules, CreatePlayers(rules));
            game.State.Changed += State_Changed;
            game.Ended += Game_Ended;

            game.Play();

            Console.ReadLine();
        }

        private static void State_Changed(object sender, EventArgs args)
        {
            BoardState state = (BoardState)sender;
            foreach (var scored in state.ScoredQueue)
            {
                Console.ForegroundColor = PlayerColors[(scored.Owner as ConsolePlayer).Number];
                Console.Write(scored);
            }
            foreach (var unscored in state.UnscoredQueue)
            {
                Console.ForegroundColor = PlayerColors[(unscored.Owner as ConsolePlayer).Number];
                Console.Write(unscored);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        private static void Game_Ended(object sender, EventArgs args)
        {
            Game game = (Game)sender;
            Console.WriteLine(game.ToString());
        }

        private static IPlayer[] CreatePlayers(IRules rules)
        {
            return Enumerable.Range(1, rules.NumberOfPlayers)
                .Select(i => new ConsolePlayer(i, $"Player {i}",  rules))
                .ToArray();
        }
    }
}
