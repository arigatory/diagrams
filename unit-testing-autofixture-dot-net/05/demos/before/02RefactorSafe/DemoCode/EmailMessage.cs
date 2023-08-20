namespace DemoCode
{
    public class EmailMessage
    {
        public EmailMessage(string toAddress, string messageBody, bool isImportant, string subject)
        {
            ToAddress = toAddress;
            MessageBody = messageBody;
            IsImportant = isImportant;
            Subject = subject;
        }


        public string ToAddress { get; private set; }
        public string MessageBody { get; private set; }
        public string Subject { get; set; }
        public bool IsImportant { get; private set; }
    }
}