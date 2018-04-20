using System;

namespace KataTDD.Lib.MontyHallProblems
{
    public class MontyGame
    {
        public static readonly Random Randomize = new Random();

        private readonly IDoorsFactory _doorsFactory;

        public MontyGame(IDoorsFactory doorsFactory)
        {
            _doorsFactory = doorsFactory;
        }

        public GameResult Run(Strategy strategy, int chooseDoor)
        {
            var doors = _doorsFactory.Create();
            switch (strategy)
            {
                case Strategy.Keep:
                    return doors[chooseDoor - 1] == Door.DoorWithCar ? GameResult.Won : GameResult.Lose;
                default:
                    return doors[chooseDoor - 1] == Door.DoorWithCar ? GameResult.Lose : GameResult.Won;
            }
        }
    }
}