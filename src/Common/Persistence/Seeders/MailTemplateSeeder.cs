﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Seeders
{
	internal sealed class MailTemplateSeeder
	{
		public static void Seed(ApplicationDBContext context)
		{
			var needExecute = context.MailTemplates.Any(user =>
				(user.BranchId == Constants.CONFIG_MASTER_BRANCH_ID)) == false;
			if (needExecute == false) return;

			// Create operator if not exist
			SeedList.ForEach(user => context.Add(user));
			context.SaveChanges();
		}

		private static Dictionary<string, string> MailBodyList = new Dictionary<string, string>()
		{
			{
				"MailContact",
				"<div style='max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);'>\r\n   <div style='margin-bottom: 20px;'>\r\n      <h2 style='color: #333; border-bottom: 2px solid #f4f4f4; padding-bottom: 10px;'>Thông tin người gửi</h2>\r\n      <p style='margin: 0; padding: 5px 0; color: #555;'>\r\n         <strong>Họ và tên:</strong>            \r\n         <mail-from-name />\r\n      </p>\r\n      <p style='margin: 0; padding: 5px 0; color: #555;'>\r\n         <strong>Email:</strong>            \r\n         <mail-from-email />\r\n      </p>\r\n      <p style='margin: 0; padding: 5px 0; color: #555;'>\r\n         <strong>Số điện thoại:</strong>            \r\n         <mail-from-tel />\r\n      </p>\r\n   </div>\r\n   <div>\r\n      <h2 style='color: #333; border-bottom: 2px solid #f4f4f4; padding-bottom: 10px;'>Nội dung mail</h2>\r\n      <mail-paragraph>\r\n         <p style='margin: 0; padding: 5px 0; color: #555;'>\r\n            <mail-paragraph-item />\r\n         </p>\r\n      </mail-paragraph>\r\n   </div>\r\n</div>"
			},
			{
				"MailOTPAuth",
				"<div style='font-family: Arial, sans-serif; background-color: #f0f0f0; padding: 20px; text-align: center;'>\r\n    <div style='background-color: #ffffff; padding: 20px; border-radius: 5px; max-width: 600px; margin: auto; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);'>\r\n        <h1 style='color: #333333;'>Mã xác nhận OTP của bạn</h1>\r\n        <p style='font-size: 16px; color: #555555;'>Chào bạn,</p>\r\n        <p style='font-size: 16px; color: #555555;'>Đây là mã OTP của bạn để xác nhận địa chỉ email:</p>\r\n        <p style='font-size: 24px; font-weight: bold; color: #000000; letter-spacing: 5px; margin: 20px 0; user-select: text;'>\r\n            <mail-otp-code />\r\n        </p>\r\n        <p style='font-size: 16px; color: #555555;'>Mã OTP có hiệu lực trong vòng 10 phút.</p>\r\n        <p style='font-size: 16px; color: #555555;'>Nếu bạn không yêu cầu mã này, vui lòng bỏ qua email này.</p>\r\n        <p style='font-size: 16px; color: #555555;'>Trân trọng,<br>Đội ngũ hỗ trợ</p>\r\n    </div>\r\n</div>"
			}
		};

		private static List<MailTemplate> SeedList = new List<MailTemplate>()
		{
			// ERP Mail to send OTP
			new MailTemplate()
			{
				BranchId = Constants.CONFIG_MASTER_BRANCH_ID,
				MailId = Constants.FLG_MAIL_ID_OTP_AUTH_MAIL,
				Subject = "[ERP Mail Verify] Xác thực đăng nhập",
				Body = MailBodyList["MailOTPAuth"],
				From = Constants.CONFIG_SMTP_USER,
				Status = MailTemplateStatusEnum.Active,
				DateCreated = DateTime.Now,
				DateChanged = DateTime.Now
			},
			// ERP Mail to operator
			new MailTemplate()
			{
				BranchId = Constants.CONFIG_MASTER_BRANCH_ID,
				MailId = Constants.FLG_MAIL_ID_CONTACT_ADMIN,
				Subject = "[ERP Mail Contact] Liên hệ từ khách hàng",
				Body = MailBodyList["MailContact"],
				From = Constants.CONFIG_SMTP_USER,
				To = Constants.CONFIG_OWNER_MAIL,
				Cc = Constants.CONFIG_OWNER_MAIL_CC,
				Bcc = Constants.CONFIG_OWNER_MAIL_BCC,
				Status = MailTemplateStatusEnum.Active,
				DateCreated = DateTime.Now,
				DateChanged = DateTime.Now
			},
			// ERP Mail to report
			new MailTemplate()
			{
				BranchId = Constants.CONFIG_MASTER_BRANCH_ID,
				MailId = Constants.FLG_MAIL_ID_REPORT_MAIL,
				Subject = "[ERP Mail Report] Báo cáo từ khách hàng",
				Body = MailBodyList["MailContact"],
				From = Constants.CONFIG_SMTP_USER,
				To = Constants.CONFIG_OWNER_MAIL,
				Cc = Constants.CONFIG_OWNER_MAIL_CC,
				Bcc = Constants.CONFIG_OWNER_MAIL_BCC,
				Status = MailTemplateStatusEnum.Active,
				DateCreated = DateTime.Now,
				DateChanged = DateTime.Now
			},
		};
	}
}
