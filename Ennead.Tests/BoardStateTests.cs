using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ennead.Tests
{
    [TestClass]
    public class BoardStateTests
    {
        private BoardState state;

        [TestInitialize]
        public void Setup()
        {
            state = new BoardState();

            state.Queue.Add(new CardSlot());
            state.Queue.Add(new CardSlot());
            state.Queue.Add(new CardSlot());
            state.Queue.Add(new CardSlot());
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
    }
}
