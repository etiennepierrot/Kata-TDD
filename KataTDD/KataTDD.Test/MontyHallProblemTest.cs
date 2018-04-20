using System;
using System.Linq;
using KataTDD.Lib.MontyHallProblems;
using NUnit.Framework;

namespace KataTDD.Test
{
    public class MontyHallProblemTest
    {
        private MontyGame _montyGame;
        private static int PositionDoorWithCar = 1;
        private static int PositionDoorWithGoat = 2;

        [SetUp]
        public void Setup()
        {
            _montyGame = new MontyGame(new StubDoorsFactory());
        }

        [Test]
        public void BuildRandomDoor()
        {
            var doors = new DoorsFactory().Create().ToArray();
            AssertPrizeAreBehindDoors(doors);
        }

        private static void AssertPrizeAreBehindDoors(Door[] doors)
        {
            Assert.That(doors.Count(x => x.Prize == Prize.Goat), Is.EqualTo(PositionDoorWithGoat));
            Assert.That(doors.Count(x => x.Prize == Prize.Car), Is.EqualTo(PositionDoorWithCar));
            Assert.That(doors.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Given_Player_Keep_Same_Door_And_Has_Choose_The_Good_One_Should_Won()
        {
            Assert.That(_montyGame.Run(Strategy.Keep, PositionDoorWithCar), Is.EqualTo(GameResult.Won));
        }

        [Test]
        public void Given_Player_Keep_Same_Door_And_Has_Choose_The_Bad_One_Should_Lose()
        {
            Assert.That(_montyGame.Run(Strategy.Keep, PositionDoorWithGoat), Is.EqualTo(GameResult.Lose));
        }

        [Test]
        public void Given_Player_Switch_Door_And_Has_Choose_First_The_Good_One_Should_Lose()
        {
            Assert.That(_montyGame.Run(Strategy.Change, PositionDoorWithCar), Is.EqualTo(GameResult.Lose));
        }

        [Test]
        public void Given_Player_Switch_Door_And_Has_Choose_First_The_Bad_One_Should_Won()
        {
            Assert.That(_montyGame.Run(Strategy.Change, PositionDoorWithGoat), Is.EqualTo(GameResult.Won));
        }

        [Test]
        public void RunStats()
        {
            var numberRuns = 1000000;
            Console.WriteLine("Strategy keep same door win " +  ResultSimulateStrategy(Strategy.Keep, numberRuns) + " times");
            Console.WriteLine("Strategy change door win " + ResultSimulateStrategy(Strategy.Change, numberRuns) + " times");
        }

        private static int ResultSimulateStrategy(Strategy strategy, int numberRuns)
        {
            return Enumerable.Range(0, numberRuns).Select(index =>
            {
                var sut = new MontyGame(new DoorsFactory());
                return sut.Run(strategy, MontyGame.Randomize.Next(1, 4));
            }).Count(r => r == GameResult.Won);
        }

        private class StubDoorsFactory : IDoorsFactory
        {
            public Door[] Create()
            {
                return new[]
                {
                    Door.DoorWithCar,
                    Door.DoorWithGoat,
                    Door.DoorWithGoat
                };
            }
        }
    }
}