// Copyright (c) 2024 - Jun Dev. All rights reserved

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
        [Route("/mail/send-mail-to-operator")]
        public string SendMailToOperator([FromForm]string subject, string message)
        {
            _mailSender.SendMailContact(subject, message);
            return _localizer.Messages["MailMessage_SendMailContactSuccess"];
        }
    }
}
