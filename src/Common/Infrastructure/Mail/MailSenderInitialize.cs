// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Infrastructure.Mail
{
    /// <summary>
    /// Mail Sender For Initialize
    /// </summary>
    /// <param name="smtpServer">Smtp server</param>
    /// <param name="smtpPort">Smtp port</param>
    /// <param name="smtpUser">Smtp user</param>
    /// <param name="smtpUserName">Smtp user name</param>
    /// <param name="smtpPass">Smtp pass</param>
    /// <param name="mailOperator">Mail operator</param>
    /// <param name="nameOperator">Name operator</param>
    internal record MailSenderInitialize(
        string smtpServer,
        int smtpPort,
        string smtpUser,
        string smtpUserName,
        string smtpPass,
        string mailOperator,
        string nameOperator);

    /// <summary>
    /// Object include information for sendmail
    /// </summary>
    /// <param name="toMail">Mail TO</param>
    /// <param name="subject">Subject</param>
    /// <param name="message">Message</param>
    /// <param name="ccMail">Mail CC</param>
    /// <param name="bccMail">Mail BCC</param>
    public record MailSenderInfo(string toMail, string subject, string message, string ccMail = "", string bccMail = "");
}
