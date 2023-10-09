using MailClient.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

		public List<MailEntity> GetMails(string userId)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Mails
					.Include(x => x.User)
					.Where(x => x.UserId == userId)
					.ToList();
			}
		}

		public MailEntity GetMail(string userId, Guid mailId)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Mails
					.Include(x => x.User)
					.Single(x => x.UserId == userId &&
								 x.MailId == mailId);
			}
		}
	}
}