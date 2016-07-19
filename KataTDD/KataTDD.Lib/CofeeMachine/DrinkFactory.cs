using System;

namespace KataTDD.Lib.CofeeMachine
{
    public class DrinkFactory
    {
        public static Drink Create(BoissonEnum boisson)
        {
            switch (boisson)
            {
                case BoissonEnum.Tea:
                    return new Tea();
                case BoissonEnum.Chocolate:
                    return new Chocolate();
                case BoissonEnum.Coffee:
                    return new Coffee();
                case BoissonEnum.Orange:
                    return new Orange();
                default:
                    throw new ArgumentOutOfRangeException(nameof(boisson), boisson, null);
            }
        }
    }
}