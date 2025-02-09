// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Interface
{
	public interface IMailSender
	{
		void SendMail(MailSenderInfo mailInfo);

		void SendMailToOperator(string subject, string message, MailPriorityEnum priority = MailPriorityEnum.Normal);

		void SendMailContact(string subject, string message);

		List<MimeMessage> readMailNotSend(int maxCount = 10);
	}
}
