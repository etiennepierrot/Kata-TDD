namespace KataTDD.Lib.CofeeMachine
{
    public class CoffeMachine
    {
        public static string Order(Order order)
        {
            string nbSugar =  order.Sugar > 0 ? order.Sugar.ToString() : "";
            BoissonEnum boissonEnum = order.Boisson;
            string x = order.Sugar > 0 ? "0" : "";
            return $"{GetCodeDrink(boissonEnum)}:{nbSugar}:{x}";
        }

        private static string GetCodeDrink(BoissonEnum boissonEnum)
        {
            switch (boissonEnum)
            {
                case BoissonEnum.Coffee:
                     return "C";
                case BoissonEnum.Tea:
                    return  "T";
                default:
                    return "H";
            }
        }

        public static string Order(string message)
        {
            return $"M:{message}";
        }
    }
}