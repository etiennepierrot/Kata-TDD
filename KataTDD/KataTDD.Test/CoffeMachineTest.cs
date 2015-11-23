using KataTDD.Lib.CofeeMachine;
using NUnit.Framework;

namespace KataTDD.Test
{
    /// <summary>
    /// "T:1:0" (Drink maker makes 1 tea with 1 sugar and a stick)
    ///"H::" (Drink maker makes 1 chocolate with no sugar -  and therefore no stick)
    ///"C:2:0" (Drink maker makes 1 coffee with 2 sugars and a stick)
    ///"M:message-content" (Drink maker forwards any message received  onto the coffee machine interface for the customer to see)
    /// </summary>
    class CoffeMachineTest
    {
        [Test]
        public void A_Tea_With_1_Sugar()
        {
            var teaWithSugar = new Order
            {
                Boisson = BoissonEnum.Tea,
                Sugar = 1,
                Stick = 1
            };

            Assert.That(CoffeMachine.Order(teaWithSugar), Is.EqualTo("T:1:0"));
        }

        [Test]
        public void A_Chocolate_Without_Sugar()
        {
            var chocolateWithoutSugar = new Order
            {
                Boisson = BoissonEnum.Chocolate,
                Sugar = 0,
                Stick = 0
            };

            Assert.That(CoffeMachine.Order(chocolateWithoutSugar), Is.EqualTo("H::"));
        }

        [Test]
        public void A_Coffee_With_2_Sugar()
        {
            var chocolateWithoutSugar = new Order
            {
                Boisson = BoissonEnum.Coffee,
                Sugar = 2,
                Stick = 1
            };

            Assert.That(CoffeMachine.Order(chocolateWithoutSugar), Is.EqualTo("C:2:0"));
        }

        [Test]
        public void Transmit_Message()
        {
            Assert.That(CoffeMachine.Order("message"), Is.EqualTo("M:message"));
        }
    }
}
