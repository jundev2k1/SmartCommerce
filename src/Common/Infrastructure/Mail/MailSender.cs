// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common.Utilities;

namespace ErpManager.Infrastructure.Mail
{
    internal class MailSender : MailSenderBase, IMailSender
    {
        public MailSender(MailSenderInitialize mailInfo) : base(mailInfo)
        {
        }

        public void SendMail(MailSenderInfo mailInfo)
        {
            Task.Run(() => this.SendMailAsync(mailInfo));
        }

        public void SendMailToOperator(string subject, string message)
        {
            Task.Run(() => this.SendMailToOperatorAsync(subject, message));
        }
    }
}
