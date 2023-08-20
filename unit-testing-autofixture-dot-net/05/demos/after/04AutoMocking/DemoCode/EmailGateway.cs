﻿using System.Diagnostics;

namespace DemoCode
{
    public class EmailGateway : IEmailGateway
    {
        public void Send(EmailMessage message)
        {
            // simulate sending email
            Debug.WriteLine("Sending email to: " + message.ToAddress);
        }
    }
}