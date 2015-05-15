using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataTDD.Lib.Diamonds;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataTDD.Test
{
    [TestClass]
    public class DiamandTest
    {
        [TestMethod]
        public void A_Should_Give_A()
        {
            Assert.AreEqual("A\n", Diamond.Create('A'));
        }

        [TestMethod]
        public void B_Should_Have_Simetry()
        {
            Assert.AreEqual(" A \nB B\n A \n", Diamond.Create('B'));
        }

        [TestMethod]
        public void C_Should_Have_Simetry()
        {
            Assert.AreEqual("  A  \n B B \nC   C\n B B \n  A  \n", Diamond.Create('C'));
        }

    }
}
