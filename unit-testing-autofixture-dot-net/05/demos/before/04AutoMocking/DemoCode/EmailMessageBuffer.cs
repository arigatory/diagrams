using System.Collections.Generic;
using System.Linq;

namespace DemoCode
{
    public class EmailMessageBuffer
    {
        private readonly List<EmailMessage> _emails = new List<EmailMessage>();

        public EmailMessageBuffer(IEmailGateway emailGateway)
        {
            EmailGateway = emailGateway;
        }
       
        public IEmailGateway EmailGateway { get; }
        public int UnsentMessagesCount => _emails.Count;
       
        public void SendAll()
        {
            for (int i = 0; i < _emails.Count; i++)
            {
                var email = _emails[i];

                Send(email);
                _emails.Remove(email);
            }
        }

        private void Send(EmailMessage email)
        {
             EmailGateway.Send(email);            
        }

        public void Add(EmailMessage message)
        {
            _emails.Add(message);
        }

        public void SendLimited(int maximumMessagesToSend)
        {
            var limitedBatchOfMessages = _emails.Take(maximumMessagesToSend).ToArray();

            for (int i = 0; i < limitedBatchOfMessages.Length; i++)
            {
                var email = limitedBatchOfMessages[i];
                Send(email);
                _emails.Remove(email);
            }
        }
    }
}