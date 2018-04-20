using System.Linq;

namespace KataTDD.Lib.MontyHallProblems
{
    public class DoorsFactory : IDoorsFactory
    {
        public Door[] Create()
        {
            var positionCar = MontyGame.Randomize.Next(0, 3);
            return Enumerable.Range(0, 3).Select(x => x == positionCar
                ? Door.DoorWithCar
                : Door.DoorWithGoat)
                .ToArray();
        }
    }
}