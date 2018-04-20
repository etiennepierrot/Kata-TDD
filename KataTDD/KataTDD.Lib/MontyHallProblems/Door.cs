namespace KataTDD.Lib.MontyHallProblems
{
    public class Door
    {
        public static readonly Door DoorWithGoat = new Door(Prize.Goat);
        public static readonly Door DoorWithCar = new Door(Prize.Car);

        private Door(Prize goat)
        {
            Prize = goat;
        }

        public Prize Prize { get; }
    }
}