using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTDD.Lib.CofeeMachine
{
    public class CoffeMachine
    {
        private readonly Report _report;

        public CoffeMachine()
        {
            _report = new Report();
        }

        public string Order(Order order)
        {
            Drink drink = DrinkFactory.Create(order.Boisson);
            if (IsEnoughMoney(drink, order.Money))
            {
                _report.Add(order.Boisson);
                return BuildCommand(drink, order.Sugar, order.Hot);
            }
            else
            {
                return Message("Not enough money");
            }
        }

        private static string BuildCommand(Drink drink, int sugar, bool hot)
        {
            string nbSugar = sugar > 0 ? sugar.ToString() : "";
            string x = sugar > 0 ? "0" : "";
            return $"{GetDrinkCode(drink, hot)}:{nbSugar}:{x}";
        }

        private static string GetDrinkCode(Drink drink, bool hot)
        {
            return hot ? $"{drink.Code}h" : drink.Code;
        }

        private static bool IsEnoughMoney(Drink drink, double amount)
        {
            return drink.Price <= amount;
        }

        private static string Message(string message)
        {
            return $"M:{message}";
        }

        public Report GetReport()
        {
            return _report;
        }
    }

    public class Report
    {
        private readonly Dictionary<BoissonEnum, int> _dictionary;

        public Report()
        {
            _dictionary = new Dictionary<BoissonEnum, int>();
        }

        public int GetCoffeeStat(BoissonEnum boisson)
        {
            return !_dictionary.ContainsKey(boisson) ? 0 : _dictionary[boisson];
        }

        public void Add(BoissonEnum boisson)
        {
            if (!_dictionary.ContainsKey(boisson))
            {
                _dictionary.Add(boisson, 1);
            }
            else
            {
                _dictionary[boisson]++;
            }
        }

        public double CA()
        {
            return (from i in _dictionary let drink = DrinkFactory.Create(i.Key) select i.Value*drink.Price).Sum();
        }
    }
}