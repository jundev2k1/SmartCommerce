// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Mail
{
    internal class MailSender : MailSenderBase, IMailSender
    {
        public MailSender() : base()
        {
        }

        public void SendMail(MailSenderInfo mailInfo)
        {
            Task.Run(() => this.SendMailAsync(mailInfo));
        }

        public void SendMailToOperator(string subject, string message, MailPriorityEnum priority = MailPriorityEnum.Normal)
        {
            Task.Run(() => this.SendMailToOperatorAsync(subject, message, priority));
        }

        public void SendMailContact(string subject, string message)
        {
            SendMailToOperator(subject, message, MailPriorityEnum.High);
        }

        public List<MimeMessage> readMailNotSend(int maxCount = 99)
        {
            var query = SearchQuery.NotSeen;
            return Task.Run(() => this.ReadEmailsAsync(query, maxCount)).Result;
        }
    }
}
