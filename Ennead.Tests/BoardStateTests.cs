using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ennead.Interfaces;
using NSubstitute;

namespace Ennead.Tests
{
    [TestClass]
    public class BoardStateTests
    {
        private BoardState state;
        private IPlayer player;
        private ICard card;

        [TestInitialize]
        public void Setup()
        {
            state = new BoardState();

            card = Substitute.For<ICard>();
            player = Substitute.For<IPlayer>();

            state.Play(card, 1);
  
            card = Substitute.For<ICard>();

            player = Substitute.For<IPlayer>();
        }

        [TestMethod]
        public void CostToPlay()
        {
            Assert.AreEqual(4, state.CostToPlay(1));
            Assert.AreEqual(3, state.CostToPlay(2));
            Assert.AreEqual(2, state.CostToPlay(3));
            Assert.AreEqual(1, state.CostToPlay(4));
        }

        [TestMethod]
        public void ValidSlots()
        {
            Assert.AreEqual(5, state.ValidSlots.Length);
        }

        [TestMethod]
        public void Play_InsertsCardInCorrectSlot()
        {
            state.Play(card, 2);

            //Assert.AreEqual(card, state.UnscoredQueue.[1].Card);
        }

        [TestMethod]
        public void Play_DecreasesPlayerGold()
        {
            state.Play(card, 2);
            
            player.Received().Gold = -3;
        }

        [TestMethod]
        public void Play_RemovesCardFromPlayerHand()
        {
            state.Play(card, 2);

            //player.HandOfCards.Received().Remove(card);
        }
    }
}
