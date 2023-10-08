using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailClient.Models.Domains
{
	public class MailEntity
	{
		public Guid MailId { get; set; }
		[Required]
		[ForeignKey("User")]
		public string UserId { get; set; }
		[Required]
		public string SenderName { get; set; }
		[Required]
		public string To { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }
		[Required]
		public string AttachmentName { get; set; }

		public ApplicationUser User { get; set; }
	}
}