using System.Collections.Generic;

namespace DemoCode
{
    public class DebugMessageBuffer
    {
        public List<string> Messages { get; set; } = new List<string>();

        public int MessagesWritten { get; private set; }

        public void WriteMessages()
        {
            foreach (var message in Messages)
            {
                // Do something with message...
                MessagesWritten++;
            }
        }
    }
}
