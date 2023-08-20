using System;

namespace DemoCode
{
    public class EmailMessage
    {
        private string _somePrivateField;

        public string SomePublicField;
        private string SomePrivateProperty { get; set; }
        public Guid Id { get; set; }
        public string ToAddress { get; set; }
        public string MessageBody { get; private set; }
        public string Subject { get; set; }
        public bool IsImportant { get; set; }

        public EmailMessageType MessageType { get; set; }

        public EmailMessage(string toAddress, string messageBody, bool isImportant)
        {
            ToAddress = toAddress;
            MessageBody = messageBody;
            IsImportant = isImportant;
        }
    }
}