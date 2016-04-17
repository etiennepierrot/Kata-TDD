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
        private const string MessageNotEnoughMoney = "M:Not enough money";
        private CoffeMachine _coffeMachine;

        private Order _hotCoffee = new Order
        {
            Boisson = BoissonEnum.Coffee,
            Sugar = 0,
            Stick = 0,
            Money = 0.6,
            Hot = true
        };

        private Order _orangeJuice = new Order
        {
            Boisson = BoissonEnum.Orange,
            Sugar = 0,
            Stick = 0,
            Money = 0.6
        };

        [SetUp]
        public void Setup()
        {
            _coffeMachine = new CoffeMachine();
        }

        [Test]
        public void A_Tea_With_1_Sugar()
        {
            var teaWithSugar = new Order
            {
                Boisson = BoissonEnum.Tea,
                Sugar = 1,
                Stick = 1,
                Money = 0.4,
            };

            Assert.That(_coffeMachine.Order(teaWithSugar), Is.EqualTo("T:1:0"));
        }

        [Test]
        public void A_Tea_With_1_Sugar_Not_Enough_Money()
        {
            var teaWithSugar = new Order
            {
                Boisson = BoissonEnum.Tea,
                Sugar = 1,
                Stick = 1,
                Money = 0.39,
            };

            Assert.That(_coffeMachine.Order(teaWithSugar), Is.EqualTo(MessageNotEnoughMoney));
        }

        [Test]
        public void A_Chocolate_Without_Sugar()
        {
            var chocolateWithoutSugar = new Order
            {
                Boisson = BoissonEnum.Chocolate,
                Sugar = 0,
                Stick = 0,
                Money = 0.5
            };

            Assert.That(_coffeMachine.Order(chocolateWithoutSugar), Is.EqualTo("H::"));
        }

        [Test]
        public void A_Chocolate_Without_Sugar_Not_Enough_Money()
        {
            var chocolateWithoutSugar = new Order
            {
                Boisson = BoissonEnum.Chocolate,
                Sugar = 0,
                Stick = 0,
                Money = 0.49
            };

            Assert.That(_coffeMachine.Order(chocolateWithoutSugar), Is.EqualTo(MessageNotEnoughMoney));
        }

        [Test]
        public void A_Coffee_With_2_Sugar()
        {
            var chocolateWithoutSugar = new Order
            {
                Boisson = BoissonEnum.Coffee,
                Sugar = 2,
                Stick = 1,
                Money = 0.6
            };

            Assert.That(_coffeMachine.Order(chocolateWithoutSugar), Is.EqualTo("C:2:0"));
        }

        [Test]
        public void A_Orange_Juice()
        {
            Assert.That(_coffeMachine.Order(_orangeJuice), Is.EqualTo("O::"));
        }


        [Test]
        public void A_Extra_Hot_Coffee()
        {
            Assert.That(_coffeMachine.Order(_hotCoffee), Is.EqualTo("Ch::"));
        }

        [Test]
        public void Test_Report_Drink_Sold()
        {
            _coffeMachine.Order(_hotCoffee);
            _coffeMachine.Order(_hotCoffee);
            _coffeMachine.Order(_orangeJuice);
            Report report = _coffeMachine.GetReport();
            Assert.That(report.GetCoffeeStat(BoissonEnum.Coffee), Is.EqualTo(2));
            Assert.That(report.CA(), Is.EqualTo(1.8));
        }

        [Test]
        public void Should_Send_Notify_If_Missing_Drink()
        {
            
        }

    }


}
