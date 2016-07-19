namespace KataTDD.Lib.CofeeMachine
{
    public interface EmailNotifier
    {
        void NotifyMissingDrink(string drink);
    }
}