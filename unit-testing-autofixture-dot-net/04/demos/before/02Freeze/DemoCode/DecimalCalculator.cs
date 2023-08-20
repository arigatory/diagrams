namespace DemoCode
{
    public class DecimalCalculator
    {
        public decimal Value { get; private set; }

        public void Subtract(decimal number)
        {
            Value -= number;
        }

        public void Add(decimal number)
        {
            Value += number;
        }
    }
}