using System;
using KataTDD.Lib.BowlingGames;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataTDD.Test
{
    [TestClass]
    public class GameTest
    {
        private Game g;


        [TestInitialize]
        public void Setup()
        {
            g = new Game();
        }

        [TestMethod]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            CallSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }

        private void CallSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }
    }
}
