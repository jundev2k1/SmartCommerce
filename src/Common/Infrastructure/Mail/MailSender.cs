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
    }
}
