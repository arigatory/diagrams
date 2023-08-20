namespace DemoCode
{
    public class IntCalculator
    {
        public int Value { get; private set; }

        public void Subtract(int number)
        {
            Value -= number;
        }

        public void Add(int number)
        {
            Value += number;
        }
    }
}
