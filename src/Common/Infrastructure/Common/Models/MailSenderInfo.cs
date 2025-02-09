// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Infrastructure.Common.Models
{
	/// <summary>
	/// Object include information for sendmail
	/// </summary>
	/// <param name="toMail">Mail TO</param>
	/// <param name="subject">Subject</param>
	/// <param name="message">Message</param>
	/// <param name="ccMail">Mail CC</param>
	/// <param name="bccMail">Mail BCC</param>
	public record MailSenderInfo(
		string toMail,
		string subject,
		string message,
		MailPriorityEnum priority = MailPriorityEnum.Normal,
		string ccMail = "",
		string bccMail = "");
}
