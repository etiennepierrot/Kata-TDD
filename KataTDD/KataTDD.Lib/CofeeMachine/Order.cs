namespace KataTDD.Lib.CofeeMachine
{
    public class Order
    {
        public BoissonEnum Boisson { get; set; }
        public int Sugar { get; set; }
        public int Stick { get; set; }
        public double Money { get; set; }
        public bool Hot { get; set; }
    }
}