namespace DemoCode
{
    public class NameJoiner
    {
        public int MyProperty { get; set; }

        public string Join(string firstName, string lastName)
        {
            return firstName + ' ' + lastName;
        }
    }
}
