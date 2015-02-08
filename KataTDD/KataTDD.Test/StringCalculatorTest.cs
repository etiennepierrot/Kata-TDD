using System;
using KataTDD.Lib.StringCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataTDD.Test
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void Add_Should_Return_0_For_An_Empty_String()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add("");

            //arrange
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Add_Should_Return_Sum_For_One_Number()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add("1");

            //arrange
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void Add_Should_Return_Sum_For_Two_Number()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add("1,2");

            //arrange
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Add_Should_Handle_NewLine_Instead_Of_Comma()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add("1\n2");

            //arrange
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Should_Not_Handle_NewLine_Followed_By_Comma()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add("1\n,");
           
        }


        [TestMethod]
        public void Add_Should_Accept_New_Delimiter()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add(";\n1;2");

            //arrange
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativesNotAllowedException))]
        public void Add_Should_Throw_NegativesNotAllowed()
        {
            //arrange
            StringCalculator sut = new StringCalculator();

            //act
            int result = sut.Add(";\n-1;2");

         
        }
    }
}
