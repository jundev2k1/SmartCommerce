// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Mail;

namespace ErpManager.Infrastructure.Interface
{
    public interface IMailSender
    {
        public void SendMail(MailSenderInfo mailInfo);

        public void SendMailToOperator(string subject, string message);
    }
}
