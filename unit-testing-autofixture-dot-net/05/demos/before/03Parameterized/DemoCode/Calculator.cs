namespace DemoCode
{
    public class Calculator
    {
        public int Value { get; private set; }

        public void Add(int number)
        {
            Value += number;
        }
    }
}
