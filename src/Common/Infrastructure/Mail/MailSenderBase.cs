// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Common.Utilities;
using ErpManager.Infrastructure.Common.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace ErpManager.Infrastructure.Mail
{
    internal class MailSenderBase
    {
        /// <summary>DI</summary>
        protected readonly string _smtpServer;
        protected readonly int _smtpPort;
        protected readonly string _smtpUser;
        protected readonly string _smtpUserName;
        protected readonly string _smtpPass;
        protected readonly string _mailOperator;
        protected readonly string _nameOperator;

        public MailSenderBase()
        {
            _smtpServer = Constants.CONFIG_SMTP_SERVER;
            _smtpPort = Constants.CONFIG_SMTP_PORT;
            _smtpUser = Constants.CONFIG_SMTP_USER;
            _smtpUserName = Constants.CONFIG_SMTP_USERNAME;
            _smtpPass = Constants.CONFIG_SMTP_PASSWORD;
            _mailOperator = Constants.CONFIG_OWNER_MAIL;
            _nameOperator = Constants.CONFIG_OWNER_NAME;
        }

        protected async Task SendMailAsync(MailSenderInfo mailInfo)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(_smtpUserName, _smtpUser));
            mailMessage.To.Add(new MailboxAddress(string.Empty, mailInfo.toMail));
            
            // Check exist mail CC
            if (string.IsNullOrWhiteSpace(mailInfo.ccMail))
                mailMessage.Cc.Add(new MailboxAddress(string.Empty, mailInfo.toMail));
            // Check exist mail BCC
            if (string.IsNullOrWhiteSpace(mailInfo.bccMail))
                mailMessage.Bcc.Add(new MailboxAddress(string.Empty, mailInfo.toMail));

            mailMessage.Subject = mailInfo.subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = mailInfo.message.ChangeToBr() };
            mailMessage.Body = bodyBuilder.ToMessageBody();

            SetMailPriority(mailMessage, mailInfo.priority);
            await ExecuteSendMail(mailMessage);
        }

        protected async Task SendMailToOperatorAsync(string subject, string message, MailPriorityEnum priority)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(_nameOperator, _smtpUser));
            mailMessage.To.Add(new MailboxAddress("", _mailOperator));
            mailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message.ChangeToBr() };
            mailMessage.Body = bodyBuilder.ToMessageBody();

            SetMailPriority(mailMessage, priority);
            await ExecuteSendMail(mailMessage);
        }

        /// <summary>
        /// Execute send mail
        /// </summary>
        /// <param name="mailMessage">Mail message</param>
        private async Task ExecuteSendMail(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUser, _smtpPass);
                await client.SendAsync(mailMessage);
                await client.DisconnectAsync(true);
            }
        }

        /// <summary>
        /// Set mail priority
        /// </summary>
        /// <param name="mailMessage">Mail message</param>
        private void SetMailPriority(MimeMessage mailMessage, MailPriorityEnum priority)
        {
            switch (priority)
            {
                case MailPriorityEnum.Low:
                    mailMessage.Priority = MessagePriority.Urgent;
                    mailMessage.Headers.Add("X-Priority", "1");
                    break;

                case MailPriorityEnum.Normal:
                    mailMessage.Priority = MessagePriority.Normal;
                    mailMessage.Headers.Add("X-Priority", "3");
                    break;

                case MailPriorityEnum.High:
                    mailMessage.Priority = MessagePriority.NonUrgent;
                    mailMessage.Headers.Add("X-Priority", "5");
                    break;
            }
        }
    }
}
