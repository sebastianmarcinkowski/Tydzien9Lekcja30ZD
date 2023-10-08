using EmailSender;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;

[assembly: OwinStartupAttribute(typeof(MailClient.Startup))]
namespace MailClient
{
	public partial class Startup
	{
		public static EmailParams EmailConfiguration;

		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);

			EmailConfiguration = SetEmailSettings();
		}

		private EmailParams SetEmailSettings()
		{

			string mailConfigFilePath = Path.Combine(
			Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? throw new InvalidOperationException(),
			"Mail.config");

			// ********** Mail.config structure **********

			// HostSmtp
			// EnableSsl
			// Port
			// SenderEmail
			// SenderEmailPassword
			// SenderName

			// ********** Mail.config example **********

			// smtp.test.com
			// true
			// 123
			// mail@test.com
			// secretpassword
			// MailClient

			StreamReader mailConfigSettingsFile = new StreamReader(mailConfigFilePath);
			List<string> mailConfigSettings = new List<string>();

			try
			{
				while (mailConfigSettingsFile.Peek() >= 0)
					mailConfigSettings.Add(mailConfigSettingsFile.ReadLine());
			}
			finally
			{
				if (mailConfigSettingsFile != null)
					mailConfigSettingsFile.Dispose();
			}

			return new EmailParams
			{
				HostSmtp = mailConfigSettings[0],
				EnableSsl = Convert.ToBoolean(mailConfigSettings[1]),
				Port = Convert.ToInt32(mailConfigSettings[2]),
				SenderEmail = mailConfigSettings[3],
				SenderEmailPassword = mailConfigSettings[4],
				SenderName = mailConfigSettings[5]
			};
		}
	}
}
