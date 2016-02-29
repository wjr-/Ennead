using Ennead.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ennead
{
    public class Game
    {
        public BoardState State { get; private set; }
        public IReadOnlyList<Player> Players { get; private set; }
        public IRules Rules { get; private set; }

        public Game(IRules rules)
        {
            State = new BoardState();
            Players = CreatePlayers(rules);
            Rules = rules;
        }

        public void Play()
        {
            Round0();

            foreach (int round in  Enumerable.Range(1, Rules.NumberOfRounds))
            {
                Round(round);
            }
        }

        private void Round0()
        {
            var player1Cards = Players[0].SelectTwoCards();
            State.PreviouslyPlayed.AddRange(player1Cards);

            foreach (Player player in Players.Skip(1))
            {
                var playerCards = player.SelectTwoCards(player1Cards[0].Category, player1Cards[1].Category);
                State.PreviouslyPlayed.AddRange(playerCards);
            }
        }

        private void Round(int roundNumber)
        {
            foreach (int turns in Enumerable.Range(1, 2))
            {
                PlayerTurns();
                
            }

            Scoring();
            //Take from previous
            //Move to previous (refresh queue)

            Players = MoveStartingPlayer();
        }

        private void PlayerTurns()
        {
            foreach (Player player in Players)
            {
                player.Play();
            }
        }

        private void Scoring()
        {
            foreach(int i in Enumerable.Range(0, State.Queue.Count))
            {
                State.Queue[i].Resolve(this);
            }
        }

        private IReadOnlyList<Player> CreatePlayers(IRules rules)
        {
            return Enumerable.Range(1, rules.NumberOfPlayers)
                .Select(i => new Player(i, rules, State))
                .ToList()
                .AsReadOnly();            
        }

        private IReadOnlyList<Player> MoveStartingPlayer()
        {
            return Players.Skip(1).Concat(new List<Player>() { Players.First() }).ToList().AsReadOnly();
        }

    }
}
