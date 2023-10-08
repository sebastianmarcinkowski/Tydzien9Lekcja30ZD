using MailClient.Models.Domains;
using System;

namespace MailClient.Models.Repositories
{
	public class MailRepository
	{
		public void Add(string userId, string senderName, string to, string title, string content, string attachmentName)
		{
			var mailId = Guid.NewGuid();

			using (var context = new ApplicationDbContext())
			{
				var mailEntity = new MailEntity
				{
					MailId = mailId,
					UserId = userId,
					SenderName = senderName,
					To = to,
					Title = title,
					Content = content,
					AttachmentName = attachmentName
				};

				context.Mails.Add(mailEntity);

				context.SaveChanges();
			}
		}
	}
}