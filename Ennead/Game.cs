using Ennead.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ennead
{
    public delegate void GameEndedHandler(object sender, EventArgs args);

    public class Game
    {
        public BoardState State { get; private set; }
        public IReadOnlyList<IPlayer> Players { get; private set; }
        public IRules Rules { get; private set; }

        public event GameEndedHandler Ended;

        public Game(IRules rules, params IPlayer[] players)
        {
            State = new BoardState();
            Players = players.ToList().AsReadOnly();
            Rules = rules;
        }

        public void Play()
        {
            Round0();

            foreach (int round in  Enumerable.Range(1, Rules.NumberOfRounds))
            {
                Round(round);
            }

            TallyScore();
        }

        private void Round0()
        {
            foreach (Player player in Players)
            {
                var playerCards = new[] { player.ChooseCard(), player.ChooseCard(), player.ChooseCard() };
                State.PreviouslyPlayed.AddRange(playerCards);
            }
        }

        private void Round(int roundNumber)
        {
            foreach (int turns in Enumerable.Range(1, Rules.NumberOfPlayerTurns))
            {
                PlayerTurns();           
            }

            Scoring();

            //Take from previous
            foreach (var player in Players)
            {
                player.GiveCards(State.PreviouslyPlayed.Where(c => c.Owner == player).ToArray());
            }
            State.PreviouslyPlayed.Clear();

            //Move to previous (refresh queue)
            State.ClearQueueToPreviouslyPlayed();

            Players = MoveStartingPlayer();
        }

        private void PlayerTurns()
        {
            foreach (Player player in Players)
            {
                player.Play(State);
            }
        }

        private void Scoring()
        {
            while(State.UnscoredQueue.Any())
            {
                State.UnscoredQueue.First().Resolve(this);
            }
        }

        private IReadOnlyList<IPlayer> MoveStartingPlayer()
        {
            return Players
                .Skip(1)
                .Concat(new [] { Players.First() })
                .ToList()
                .AsReadOnly();
        }

        private void TallyScore()
        {
            if(Ended != null)
            {
                Ended(this, new EventArgs());
            }          
        }

        public override string ToString()
        {
            string str = "";

            str += Players.Select(p => p.ToString()).Aggregate((acc, p) => acc + p + " ");

            return str;
        }
    }
}
