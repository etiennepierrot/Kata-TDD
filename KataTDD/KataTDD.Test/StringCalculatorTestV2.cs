using System;
using KataTDD.Lib.StringCalculatorsV2;
using Moq;
using NUnit.Framework;

namespace KataTDD.Test
{
    public class StringCalculatorV2Test
    {
        private StringCalculator _stringCalculator;
        private Mock<ILogger> _mockLogger;
        private Mock<IWebService> _mockWebService;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger>();
            _mockWebService = new Mock<IWebService>();
            _stringCalculator = new StringCalculator(_mockLogger.Object, _mockWebService.Object);
        }

        [Test]
        public void Add_Empty_String_Should_Return_0()
        {
            Assert.That(_stringCalculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        public void Add_One_Number_Should_Return_Number()
        {
            Assert.That(_stringCalculator.Add("1"), Is.EqualTo(1));
        }

        [Test]
        public void Add_Two_Number_Separed_By_Comma_Should_Return_Sum()
        {
            Assert.That(_stringCalculator.Add("1,2"), Is.EqualTo(3));
        }

        [Test]
        public void Add_Three_Number_Separed_By_Comma_And_NewLine_Should_Return_Sum()
        {
            Assert.That(_stringCalculator.Add("1\n2,3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_Should_Support_Custom_Seperator()
        {
            Assert.That(_stringCalculator.Add("//;\n1;2"), Is.EqualTo(3));
        }

        [Test]
        public void Add_Should_Throw_Exception_Given_Negative_Number()
        {
            try
            {
                _stringCalculator.Add("-1,1");
                Assert.Fail("No NegativeNotAllowedException throw");
            }
            catch (Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("negatives not allowed " + "-1" ));
            }
        }

        [Test]
        public void Add_Should_Throw_Exception_Given_Multiple_Negative_Number()
        {
            try
            {
                _stringCalculator.Add("-1,-2");
                Assert.Fail("No NegativeNotAllowedException throw");
            }
            catch (Exception e)
            {
                Assert.That(e.Message, Is.EqualTo("negatives not allowed " + "-1 -2"));
            }
        }

        [Test]
        public void Add_Should_Ignore_Number_Superior_To_1000()
        {
            Assert.That(_stringCalculator.Add("2,1001"), Is.EqualTo(2));
        }

        [Test]
        public void Custom_Delimitor_Could_Have_Any_Lenght()
        {
            Assert.That(_stringCalculator.Add("//[***]\n1***2"), Is.EqualTo(3));
        }

        [Test]
        public void Allow_Multiple_Delimitor()
        {
            Assert.That(_stringCalculator.Add("//[*][%]\n1*2%3"), Is.EqualTo(6));
        }

        [Test]
        public void Allow_Multiple_Delimitor_More_Than_One_Char()
        {
            Assert.That(_stringCalculator.Add("//[***][%%%]\n1***2%%%3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_Should_Log_Result()
        {
            _mockLogger.Setup(x => x.Write("3")).Throws(new Exception());
            _stringCalculator.Add("1,2");
            _mockWebService.Verify(x => x.Notify("logger fail"));
        }
    }
}
