// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Common.Utilities;

namespace ErpManager.ERP.Controllers
{
	public sealed class MailController : BaseController
	{
		private readonly IMailSender _mailSender;

		public MailController(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			IFileLogger logger,
			IMailSender mailSender)
			: base(serviceFacade, sessionManager, localizer, logger)
		{
			_mailSender = mailSender;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_MAIL_SENDMAIL_CONTACT_OPERATOR)]
		public IActionResult SendMailToOperator([FromBody] FormContactRequestViewModel mailInfo)
		{
			var mailId = mailInfo.Type switch
			{
				FormContactTypeEnum.ContactAdmin => Constants.FLG_MAIL_ID_CONTACT_ADMIN,
				FormContactTypeEnum.Report => Constants.FLG_MAIL_ID_REPORT_MAIL,
				_ => string.Empty
			};
			var mail = _serviceFacade.MailTemplates.Get(this.OperatorBranchId, mailId);
			if (mail == null) return BadRequest("Mail ID is not exists");

			var mailInput = new Hashtable
			{
				{ Constants.MAILDATA_KEY_MAIL_FROM_NAME, mailInfo.Name },
				{ Constants.MAILDATA_KEY_MAIL_FROM_EMAIL, mailInfo.Email },
				{ Constants.MAILDATA_KEY_MAIL_FROM_TEL, mailInfo.Tel },
				{ Constants.MAILDATA_KEY_MAIL_PARAGRAPH, mailInfo.Message },
			};
			var message = MailUtility.ReplaceBodyMail(mail.Body, mailInput);
			_mailSender.SendMailContact(mail.Subject, message);
			return Json(_localizer.Messages["MailMessage_SendMailContactSuccess"].Value);
		}
	}
}
